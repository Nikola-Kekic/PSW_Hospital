using Hospital.Dto;
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

        public AuthResponseDto GetToken(LoginRequest loginRequest)
        {
            AuthResponseDto response = ValidateUser(loginRequest.Email, loginRequest.Password);

            return response;
        }

        public string CreateToken(User user)
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

        public AuthResponseDto ValidateUser(string email, string password)
        {
            AuthResponseDto response = null;

            User user = _unitOfWork.User.GetAllUsers().FirstOrDefault(user =>
                user.Email.Equals(email, StringComparison.OrdinalIgnoreCase)
                && user.Password == password);

            if (user != null)
            {
                string token = CreateToken(user);
                response = new AuthResponseDto { Role = user.Role.ToString(), Token = token };
            }

            return response;
        }

        public User Register(User user)
        {
            User retVal = null;

            User existingUser = _unitOfWork.User.FindByCondition(x => x.Email.Equals(user.Email)).FirstOrDefault();
            // user exists => return error

            if (existingUser == null)
            {
                retVal = _unitOfWork.User.Create(user);
                _unitOfWork.Save();
            }

            return retVal;
        }
    }
}
