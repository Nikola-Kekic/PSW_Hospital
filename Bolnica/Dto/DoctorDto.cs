using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Dto
{
    public class DoctorDto
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Specialization Specialization { get; set; }
        public string SpecializationString { get; set; }
        public DoctorDto() { }
    }
}
