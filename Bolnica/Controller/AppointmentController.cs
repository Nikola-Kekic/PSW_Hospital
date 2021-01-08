using Hospital.Dto;
using Hospital.Model;
using Hospital.Repository;
using Hospital.Repository.Interfaces;
using Hospital.Service;
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
        private IAppointmentService _appointmentService;
        public AppointmentController(IUnitOfWork unitOfWork, IAppointmentService appointmentService)
        {
            _unitOfWork = unitOfWork;
            _appointmentService = appointmentService;
        }

        // GET: api/Appointment
        [HttpGet]
        public ActionResult GetAppointments()
        {
            return Ok(_unitOfWork.Appointment.GetAllAppointments().ToList());
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
        [Route("doctor")]
        public ActionResult GetAppointmentsForDoctor(AppointmentRequestDto dto)
        {
            return Ok(_appointmentService.GetAppointmentRecommendations(dto).ToList());
        }
    }
}
