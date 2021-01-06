using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Model
{
    public class Appointment
    {
        public long Id { get; set; }
        public DateTime StartTime { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }

    }
}
