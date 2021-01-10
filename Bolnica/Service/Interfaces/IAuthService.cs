using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Service.Interfaces
{
    public interface IAuthService
    {
        string GetToken(LoginRequest loginRequest);
        string CreateToken(Patient user);
        Patient Register(Patient patient);
        string ValidateUser(string email, string password);
    }
}
