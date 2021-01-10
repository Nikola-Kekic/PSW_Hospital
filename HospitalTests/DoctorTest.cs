using Hospital.Context;
using Hospital.Controller;
using Hospital.Dto;
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
            //_doctorController = new DoctorController(_mockService.Object);

            HospitalContext context = new HospitalContext();
            UnitOfWork unitOfWork = new UnitOfWork(context);
            DoctorService doctorService = new DoctorService(unitOfWork);
            _doctorController = new DoctorController(doctorService);
        }

        // fails because of mock objects
        [Fact]
        public void Checks_create_doctor()
        {
            // arrange
            var doctorDto = new DoctorDto
            {
                Id = 4,
                FirstName = "Mario",
                LastName = "Markovic",
                Specialization = Specialization.GYNECOLOGY
            };

            ActionResult actionResult = _doctorController.CreateDoctor(doctorDto);

            Doctor doctorResult = (actionResult as CreatedAtActionResult).Value as Doctor;

            Assert.NotNull(actionResult);
            Assert.True(doctorResult.FirstName == doctorDto.FirstName);
            Assert.True(doctorResult.LastName == doctorDto.LastName);
            Assert.True(doctorResult.Specialization == doctorDto.Specialization);
        }
    }
}
