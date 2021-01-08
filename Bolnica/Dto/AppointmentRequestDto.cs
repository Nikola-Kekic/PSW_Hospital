using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Dto
{
    //dolazi sa fronta
    public class AppointmentRequestDto
    {
        public long DoctorId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public bool DoctorIsPriority { get; set; }
    }
}
