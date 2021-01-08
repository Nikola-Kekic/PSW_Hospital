using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Repository.Interfaces
{
    public interface IAppointmentRepository : IRepositoryBase<Appointment>
    {
        IEnumerable<Appointment> GetAllAppointments();
        Appointment GetAppointmentById(long Id);
        IEnumerable<Appointment> GetFreeAppointmentsForDoctor(DateTime from, DateTime to, long doctorId);
        void DeleteAppointment(Appointment appointment);

    }
}
