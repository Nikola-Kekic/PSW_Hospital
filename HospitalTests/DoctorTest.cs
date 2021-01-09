using Hospital.Context;
using Hospital.Controller;
using Hospital.Model;
using Hospital.Repository;
using Hospital.Repository.Interfaces;
using Hospital.Service;
using Hospital.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HospitalTests
{
    public class DoctorTest
    {
        private Mock<IUnitOfWork> _mockRepository;
        private Mock<IDoctorService> _mockService;
        private DoctorController _doctorController;

        public DoctorTest()
        {
            _mockRepository = new Mock<IUnitOfWork>();
            _mockService = new Mock<IDoctorService>();
            _doctorController = new DoctorController(_mockService.Object);

        }

        // fails because of mock objects
        [Fact]
        public void Checks_find_doctor_by_id()
        {
            // arrange
            var doctor = new Doctor
            {
                Id = 2,
                FirstName = "Marko",
                LastName = "Markovic",
                Specialization = Specialization.CARDIOLOGY
            };

            // act
            IActionResult actionResult = _doctorController.GetDoctor(doctor.Id);
            var okResult = actionResult as OkObjectResult;
            Doctor doctorResult = okResult.Value as Doctor;

            // assert
            Assert.NotNull(okResult);
            Assert.True(doctorResult.FirstName == doctor.FirstName);
        }
    }
}
