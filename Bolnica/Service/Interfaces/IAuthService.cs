using Hospital.Dto;
using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Service.Interfaces
{
    public interface IAuthService
    {
        AuthResponseDto GetToken(LoginRequest loginRequest);
        string CreateToken(User user);
        User Register(User user);
        AuthResponseDto ValidateUser(string email, string password);
    }
}
