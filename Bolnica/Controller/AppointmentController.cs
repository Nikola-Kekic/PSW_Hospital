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
        private IUnitOfWork _unitOfWork;
        public AppointmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Appointment
        [HttpGet]
        public ActionResult GetAppointments()
        {
            return Ok(_unitOfWork.Appointment.FindAll());
        }

        // POST: api/Appointment/period
        [HttpPost]
        [Route("period")]
        public ActionResult GetAppointmentsForPeriod(AppointmentRequestDto dto)
        {
            throw new NotImplementedException();
        }

        // POST: api/Appointment/doctor
        [HttpPost]
        [Route("searchDoctor")]
        public ActionResult GetAppointmentsForDoctor(AppointmentRequestDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
