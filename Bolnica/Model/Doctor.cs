using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Model
{
    public class Doctor
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Specialization Specialization { get; set; }

        public Doctor(int id, string firstName, string lastName, Specialization specialization)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Specialization = specialization;
        }

        public Doctor() { }
    }
}
