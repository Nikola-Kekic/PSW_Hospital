using Hospital.Model;
using Hospital.Repository.Interfaces;
using Hospital.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Service
{
    public class PatientService : IPatientService
    {
        private IUnitOfWork _unitOfWork;

        public PatientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Patient CreatePatient(Patient patient)
        {
            var retVal = _unitOfWork.Patient.Create(patient);
            _unitOfWork.Save();

            return retVal;
        }


        public IEnumerable<Patient> GetAllPatients()
        {
            throw new NotImplementedException();
        }

        public Patient GetPatient(long id)
        {
            return _unitOfWork.Patient.GetPatientById(id);
        }

        public void DeletePatient(long id)
        {
            var patient = _unitOfWork.Patient.GetPatientById(id);

            if (patient != null)
                _unitOfWork.Patient.Delete(patient);

            _unitOfWork.Save();
        }
    }
}
