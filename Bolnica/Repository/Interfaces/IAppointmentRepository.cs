using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Repository.Interfaces
{
    public interface IAppointmentRepository : IRepositoryBase<Appointment>
    {
        IEnumerable<Appointment> GetAllAppointmentsAsync();
        Appointment GetAppointmentByIdAsync(long Id);
        Appointment GetAppointmentWithDetailsAsync(long Id);
        void DeleteAppointment(Appointment appointment);

    }
}
