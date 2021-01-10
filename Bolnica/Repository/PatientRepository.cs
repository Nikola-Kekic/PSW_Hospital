using Hospital.Context;
using Hospital.Model;
using Hospital.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Repository
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        public PatientRepository(HospitalContext context) : base(context)
        {
        }

        public IEnumerable<Patient> GetAllPatients()
        {
            return FindAll()
                .OrderBy(a => a.Id)
                .ToList();
        }

        public Patient GetPatientById(long Id)
        {
            return FindByCondition(t => t.Id.Equals(Id))
                .FirstOrDefault();
        }

        public Patient GetPatientWithDetails(long Id)
        {
            return FindByCondition(a => a.Id.Equals(Id))
                .FirstOrDefault();
        }

        public void DeletePatient(Patient patient)
        {
            Delete(patient);
        }


    }
}

