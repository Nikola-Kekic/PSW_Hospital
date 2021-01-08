using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Repository.Interfaces
{
    public interface IDoctorRepository : IRepositoryBase<Doctor>
    {
        IEnumerable<Doctor> GetAllDoctorsAsync();
        Doctor GetDoctorByIdAsync(long Id);
        Doctor GetDoctorWithDetailsAsync(long Id);
        void DeleteDoctor(Doctor doctor);
    }
}
