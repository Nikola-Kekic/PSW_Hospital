using Hospital.Adapter;
using Hospital.Dto;
using Hospital.Model;
using Hospital.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // POST: api/Auth/login
        [HttpPost]
        [Route("login")]
        public ActionResult Login(LoginRequest loginRequest)
        {

            AuthResponseDto response = _authService.GetToken(loginRequest);
            
            if(response != null)
            {
                return Ok(response);

            }

            return BadRequest();
        }

        // POST: api/Auth/register
        [HttpPost]
        [Route("register")]
        public ActionResult Register(UserDto dto)
        {
            User user = UserAdapter.UserDtoToUser(dto);

            user = _authService.Register(user);

            if(user != null)
                return Ok(user);
            else
                // already exists code
                return StatusCode(409);
        }
    }
}
