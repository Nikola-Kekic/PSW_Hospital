using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Dto
{
    public class AppointmentDto
    {
        public DateTime StartTime { get; set; }
        public DoctorDto Doctor { get; set; }
        public UserDto User { get; set; }
    }
}
