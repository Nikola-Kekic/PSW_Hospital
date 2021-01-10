using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Service.Interfaces
{
    public interface IPatientService
    {
        public IEnumerable<Patient> GetAllPatients();
        public Patient GetPatient(long id);
        public Patient CreatePatient(Patient patient);
        public void DeletePatient(long id);
    }
}
