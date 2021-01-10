using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        IAppointmentRepository Appointment { get; }
        IDoctorRepository Doctor { get; }
        IPatientRepository Patient { get; }
        void Save();
    }
}
