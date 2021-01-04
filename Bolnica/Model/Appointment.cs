using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Model
{
    public class Appointment
    {
        private long Id { get; set; }
        private DateTime StartTime { get; set; }
        private Doctor Doctor { get; set; }
        private Patient Patient { get; set; }

    }
}
