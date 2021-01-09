using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Service.Interfaces
{
    public interface IDoctorService
    {
        public IEnumerable<Doctor> GetAllDoctors();
        public Doctor GetDoctor(long id);
        public Doctor CreateDoctor(Doctor doctor);
        public void DeleteDoctor(long id);
    }
}
