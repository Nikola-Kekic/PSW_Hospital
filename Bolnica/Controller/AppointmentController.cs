using Hospital.Dto;
using Hospital.Model;
using Hospital.Repository;
using Hospital.Repository.Interfaces;
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
        private UnitOfWork _unitOfWork;
        public AppointmentController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Appointment
        [HttpGet]
        public IActionResult GetAppointments()
        {
            return Ok(_unitOfWork.Appointment.FindAll());
        }

        // POST: api/Appointment
        [HttpPost]
        public IActionResult GetAppointments(AppointmentRequestDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
