using Hospital.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        public AppointmentController()
        {
        }
        // GET: api/Appointment
        [HttpGet]
        public IActionResult GetAppointments()
        {
            return Ok(new List<Appointment>());
        }
    }
}
