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
        public DbSet<User> Users { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public IConfiguration Configuration { get; }

        public HospitalContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public HospitalContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                optionsBuilder
                .UseSqlServer(Configuration["ConnectionStrings:HospitalConnection"]);
            } catch(Exception e)
            {
                // a database only in case of testing
                Console.WriteLine(e.Message);
                optionsBuilder
                .UseSqlServer("Data Source=DESKTOP-SUEUN9H;Initial Catalog=HospitalTest;MultipleActiveResultSets=true;Integrated Security=True");
            }
            optionsBuilder.UseLazyLoadingProxies();

        }
    }
}
