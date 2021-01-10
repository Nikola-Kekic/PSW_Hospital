using Hospital.Model;
using Hospital.Repository.Interfaces;
using Hospital.Service.Interfaces;
using Microsoft.Exchange.WebServices.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service
{
    public class AuthService : IAuthService
    {
        private IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public AuthService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        public string GetToken(LoginRequest loginRequest)
        {
            string token = ValidateUser(loginRequest.Email, loginRequest.Password);

            return token;
        }

        public string CreateToken(Patient user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public string ValidateUser(string email, string password)
        {
            string response = "";
            
            Patient user = _unitOfWork.Patient.GetAllPatients().FirstOrDefault(user =>
                user.Email.Equals(email, StringComparison.OrdinalIgnoreCase)
                && user.Password == password);

            if (user == null)
            {
                response = null;
            }
            else
            {
                response = CreateToken(user);
            }

            return response;
        }

        public Patient Register(Patient patient)
        {
            throw new NotImplementedException();
        }
    }
}
