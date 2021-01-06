using Hospital.Context;
using Hospital.Model;
using Hospital.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Repository
{
    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(HospitalContext context) : base(context)
        {
        }

        public IEnumerable<Appointment> GetAllAppointmentsAsync()
        {
            return FindAll()
                .OrderBy(a => a.Id)
                .ToList();
        }

        public Appointment GetAppointmentByIdAsync(long Id)
        {
            return FindByCondition(t => t.Id.Equals(Id))
                .FirstOrDefault();
        }

        public Appointment GetAppointmentWithDetailsAsync(long Id)
        {
            return FindByCondition(a => a.Id.Equals(Id))
                .FirstOrDefault();
        }

        public void DeleteAppointment(Appointment appointment)
        {
            // fizicko brisanje
            Delete(appointment);

            /* logicko brisanje
            if (!appointment.Deleted)
            {
                appointment.Deleted = true;
            }*/
        }

    }
}
