using Hospital.Context;
using Hospital.Model;
using Hospital.Repository;
using Hospital.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HospitalTests
{
    public class DoctorTest
    {

        private IDoctorRepository _doctorRepository;
        private HospitalContext _hospitalContext;
        public IConfiguration Configuration;

        public DoctorTest()
        {
            _hospitalContext = new HospitalContext(Configuration);
            _doctorRepository = new DoctorRepository(_hospitalContext);
        }


        [Fact]
        //[MemberData(nameof(Data))]
        public void Checks_find_doctor_by_id()
        {
            // arrange
            var doctor = new Doctor
            {
                FirstName = "Marko",
                LastName = "Markovic",
                Specialization = Specialization.CARDIOLOGY
            };


            // act

            // assert

        }
    }
}
