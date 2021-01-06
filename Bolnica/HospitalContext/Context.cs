using Hospital.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Context
{
    public class HospitalContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public IConfiguration Configuration { get; }

        public HospitalContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
     
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder
                .UseSqlServer(Configuration["ConnectionStrings:HospitalConnection"]);
            
        }
    }
}
