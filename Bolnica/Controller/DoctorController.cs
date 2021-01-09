using Hospital.Adapter;
using Hospital.Dto;
using Hospital.Model;
using Hospital.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        // GET: api/Doctor
        [HttpGet]
        public ActionResult GetDoctors()
        {
            return Ok(_doctorService.GetAllDoctors().ToList());
        }

        // GET: api/Doctor/5
        [HttpGet("{id}")]
        public ActionResult GetDoctor(long id)
        {
            var doctor = _doctorService.GetDoctor(id);

            if (doctor == null)
            {
                return NotFound();
            }

            return Ok(doctor);
        }

        // POST: api/Doctor
        [HttpPost]
        public ActionResult CreateDoctor(DoctorDto dto)
        {
            Doctor doctor = DoctorAdapter.DoctorDtoToDoctor(dto);

            doctor = _doctorService.CreateDoctor(doctor);

            return CreatedAtAction(nameof(GetDoctor), new { id = doctor.Id }, doctor);
        }

        // DELETE: api/Doctor
        [HttpDelete("{id}")]
        public ActionResult DeleteDoctor(long id)
        {
            _doctorService.DeleteDoctor(id);

            return NoContent();
        }
    }
}
