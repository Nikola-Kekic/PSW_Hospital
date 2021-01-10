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
        Patient Register(Patient patient);
    }
}
