using Hospital.Adapter;
using Hospital.Dto;
using Hospital.Model;
using Hospital.Service.Interfaces;
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

            string token = _authService.GetToken(loginRequest);

            return Ok(token);
        }

        // POST: api/Auth/register
        [HttpPost]
        [Route("register")]
        public ActionResult Register(PatientDto dto)
        {
            Patient patient = PatientAdapter.PatientDtoToPatient(dto);

            patient = _authService.Register(patient);

            return Ok(patient);
        }
    }
}
