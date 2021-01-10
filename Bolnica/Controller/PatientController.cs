using Hospital.Adapter;
using Hospital.Dto;
using Hospital.Model;
using Hospital.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Controller
{
    [Authorize(Roles = "ADMIN")]
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        // GET: api/Patient
        [HttpGet]
        public ActionResult GetPatients()
        {
            return Ok(_patientService.GetAllPatients().ToList());
        }

        [AllowAnonymous]
        // GET: api/Patient/5
        [HttpGet("{id}")]
        public ActionResult GetPatient(long id)
        {
            var patient = _patientService.GetPatient(id);

            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient);
        }

        // POST: api/Patient
        [HttpPost]
        public ActionResult CreateDoctor(PatientDto dto)
        {
            Patient patient = PatientAdapter.PatientDtoToPatient(dto);

            patient = _patientService.CreatePatient(patient);

            return CreatedAtAction(nameof(GetPatient), new { id = patient.Id }, patient);
        }

        // DELETE: api/Patient
        [HttpDelete("{id}")]
        public ActionResult DeletePatient(long id)
        {
            _patientService.DeletePatient(id);

            return NoContent();
        }

    }
}
