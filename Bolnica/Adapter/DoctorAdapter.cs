using Hospital.Dto;
using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Adapter
{
    public class DoctorAdapter
    {
        public static Doctor DoctorDtoToDoctor(DoctorDto dto)
        {
            Doctor doctor = new Doctor();
            doctor.FirstName = dto.FirstName;
            doctor.LastName = dto.LastName;
            doctor.Specialization = dto.Specialization;
            return doctor;
        }

        public static DoctorDto DoctorToDoctorDto(Doctor doctor)
        {
            DoctorDto dto = new DoctorDto();
            dto.FirstName = doctor.FirstName;
            dto.LastName = doctor.LastName;
            dto.Specialization = doctor.Specialization;
            return dto;
        }
    }
}
