using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Repository.Interfaces
{
    public interface IPatientRepository : IRepositoryBase<Patient>
    {
        IEnumerable<Patient> GetAllPatients();
        Patient GetPatientById(long Id);
        Patient GetPatientWithDetails(long Id);
        void DeletePatient(Patient patient);
    
    }
}
