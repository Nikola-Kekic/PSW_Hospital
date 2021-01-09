using Hospital.Model;
using Hospital.Repository.Interfaces;
using Hospital.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Service
{
    public class DoctorService: IDoctorService
    {
        private IUnitOfWork _unitOfWork;

        public DoctorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<Doctor> GetAllDoctors()
        {
            throw new NotImplementedException();
        }

        public Doctor GetDoctor(long id)
        {
            return _unitOfWork.Doctor.GetDoctorById(id);
        }

        public Doctor CreateDoctor(Doctor doctor)
        {
            var retVal = _unitOfWork.Doctor.Create(doctor);
            _unitOfWork.Save();

            return retVal;
        }

        public void DeleteDoctor(long id)
        {
            var doctor = _unitOfWork.Doctor.GetDoctorById(id);
            
            if(doctor != null)
                _unitOfWork.Doctor.Delete(doctor);
            
            _unitOfWork.Save();
        }

    }
}
