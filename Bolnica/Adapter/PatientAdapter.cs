using Hospital.Dto;
using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Adapter
{
    public class PatientAdapter
    {
        public static Patient PatientDtoToPatient(PatientDto dto)
        {
            Patient patient = new Patient();
            patient.FirstName = dto.FirstName;
            patient.LastName = dto.LastName;
            patient.Email = dto.Email;
            patient.Address = dto.Address;
            patient.PhoneNumber = dto.PhoneNumber;
            patient.Password = dto.Password;

            return patient;
        }

        public static PatientDto PatientToPatientDto(Patient patient)
        {
            PatientDto dto = new PatientDto();
            dto.FirstName = patient.FirstName;
            dto.LastName = patient.LastName;
            dto.Email = patient.Email;
            dto.Address = patient.Address;
            dto.PhoneNumber = patient.PhoneNumber;
           
            return dto;
        }
    }
}
