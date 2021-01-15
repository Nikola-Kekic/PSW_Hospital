using Hospital.Dto;
using Hospital.Model;
using Hospital.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Adapter
{
    public class DoctorAdapter
    {
        private static IUnitOfWork _unitOfWork;
        public DoctorAdapter(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

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
            dto.Id = doctor.Id;
            dto.FirstName = doctor.FirstName;
            dto.LastName = doctor.LastName;
            dto.Specialization = doctor.Specialization;

            switch (doctor.Specialization)
            {
                case Specialization.CARDIOLOGY:
                    dto.SpecializationString = "Cardiology";
                    break;
                case Specialization.ONCOLOGY:
                    dto.SpecializationString = "Oncology";
                    break;
                case Specialization.GYNECOLOGY:
                    dto.SpecializationString = "Gynecology";
                    break;
                case Specialization.PULMONOLOGY:
                    dto.SpecializationString = "Pulomonology";
                    break;
                case Specialization.UROLOGY:
                    dto.SpecializationString = "Urology";
                    break;
                case Specialization.GENERAL_PRACTICE:
                    dto.SpecializationString = "General practice";
                    break;
            }

            return dto;
        }
    }
}
