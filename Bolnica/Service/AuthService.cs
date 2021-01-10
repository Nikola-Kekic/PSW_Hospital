using Hospital.Model;
using Hospital.Repository.Interfaces;
using Hospital.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Service
{
    public class AuthService : IAuthService
    {
        private IUnitOfWork _unitOfWork;

        public AuthService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public string GetToken(LoginRequest loginRequest)
        {
            Patient patient = ValidateUser(loginRequest.Email, loginRequest.Password);

            if(patient != null)
                return "token";

            return null;
        }

        public Patient ValidateUser(string email, string password)
        {
            var list = _unitOfWork.Patient.GetAllPatients();
            return _unitOfWork.Patient.GetAllPatients().FirstOrDefault(user =>
                user.Email.Equals(email, StringComparison.OrdinalIgnoreCase)
                && user.Password == password);
        }

        public Patient Register(Patient patient)
        {
            throw new NotImplementedException();
        }
    }
}
