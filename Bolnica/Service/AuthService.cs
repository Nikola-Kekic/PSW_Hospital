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
            return "token";
        }

        public Patient Register(Patient patient)
        {
            throw new NotImplementedException();
        }
    }
}
