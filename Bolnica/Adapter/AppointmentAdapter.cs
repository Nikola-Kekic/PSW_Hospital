using Hospital.Dto;
using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Adapter
{
    public class AppointmentAdapter
    {
        public static Appointment AppointmentDtoToAppointment(AppointmentDto dto)
        {
            Appointment appointment = new Appointment();
            appointment.StartTime = dto.StartTime;

            appointment.Doctor = DoctorAdapter.DoctorDtoToDoctor(dto.Doctor);

            if (dto.User != null)
                appointment.User = UserAdapter.UserDtoToUser(dto.User);

            return appointment;

        }

        public static AppointmentDto AppointmentToAppointmentDto(Appointment appointment)
        {
            AppointmentDto dto = new AppointmentDto();
            dto.StartTime = appointment.StartTime;
            dto.Doctor = DoctorAdapter.DoctorToDoctorDto(appointment.Doctor);

            if(appointment.User != null)
                dto.User = UserAdapter.UserToUserDto(appointment.User);

            return dto;
        }
    }
}
