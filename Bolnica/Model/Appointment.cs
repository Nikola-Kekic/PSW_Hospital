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
        public virtual Doctor Doctor { get; set; }
        public virtual User User { get; set; }

        // if there's no patient for this appointment, then it's free
        public bool IsFree()
        {
            return User == null;
        }
    }
}
