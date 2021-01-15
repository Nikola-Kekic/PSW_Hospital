using Hospital.Adapter;
using Hospital.Dto;
using Hospital.Model;
using Hospital.Repository;
using Hospital.Repository.Interfaces;
using Hospital.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Controller
{
    [Authorize(Roles = "PATIENT, ADMIN")]
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
            return Ok(_appointmentService.GetAppointments());
        }

        // GET: api/Appointment/5
        [HttpGet("{id}")]
        public ActionResult GetAppointment(long id)
        {
            var appointment = _appointmentService.GetAppointment(id);

            if (appointment == null)
            {
                return NotFound();
            }

            return Ok(appointment);
        }

        // POST: api/Appointment
        [HttpPost]
        public ActionResult CreateFreeAppointment(AppointmentDto dto)
        {
            Appointment appointment = AppointmentAdapter.AppointmentDtoToAppointment(dto);
            
            Doctor doctor = null;
            
            if(appointment.Doctor.Id == 0)
            {
                doctor = _unitOfWork.Doctor.GetDoctorById(dto.Doctor.Id);
            }

            appointment = _appointmentService.CreateAppointment(appointment, doctor);

            return CreatedAtAction(nameof(GetAppointment), new { id = appointment.Id }, appointment);
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
