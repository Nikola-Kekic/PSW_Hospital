using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Model
{
    public class Doctor
    {
        private long Id { get; set; }
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private Specialization Specialization { get; set; }

    }
}
