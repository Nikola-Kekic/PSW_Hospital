using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Repository.Interfaces
{
    public interface IDoctorRepository : IRepositoryBase<Doctor>
    {
        IEnumerable<Doctor> GetAllDoctors();
        Doctor GetDoctorById(long Id);
        Doctor GetDoctorWithDetails(long Id);
        void DeleteDoctor(Doctor doctor);
    }
}
