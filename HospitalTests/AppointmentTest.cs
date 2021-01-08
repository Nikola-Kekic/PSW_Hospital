using Hospital.Context;
using Hospital.Dto;
using Hospital.Model;
using Hospital.Repository;
using Hospital.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using Moq;
using Hospital.Controller;
using Microsoft.AspNetCore.Mvc;
using Hospital.Service;

namespace HospitalTests
{
    public class AppointmentTest
    {
        /* Snake case notation necessary */

        private AppointmentController _appointmentController;
        private Mock<IUnitOfWork> _mockRepository;
        private Mock<IAppointmentService> _mockService;
        public IList<Appointment> _freeAppointments { get; set; }

        public AppointmentTest()
        {
            Seed();

            _mockRepository = new Mock<IUnitOfWork>();
            _mockService = new Mock<IAppointmentService>();
            _appointmentController = new AppointmentController(_mockRepository.Object, _mockService.Object);

        }

        private void Seed()
        {
            _freeAppointments = new List<Appointment>
            {
                new Appointment { 
                    StartTime = DateTime.Parse("1/9/2021 9:30:00 AM", System.Globalization.CultureInfo.InvariantCulture),
                    Doctor = new Doctor{ FirstName = "Marko", LastName = "Markovic", Specialization = Specialization.CARDIOLOGY, Id = 1},
                    Patient = null,
                    Id = 1
                },
                new Appointment { 
                    StartTime = DateTime.Parse("1/8/2021 3:00:00 PM", System.Globalization.CultureInfo.InvariantCulture),
                    Doctor = new Doctor{ FirstName = "Marina", LastName = "Markovic", Specialization = Specialization.GENERAL_PRACTICE, Id = 2},
                    Patient = null,
                    Id = 2
                }
            };
        }

        public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
             new object[]
             {
                 new Appointment {
                     StartTime = DateTime.Parse("1/9/2021 9:30:00 AM", System.Globalization.CultureInfo.InvariantCulture),
                     Doctor = new Doctor{ FirstName = "Marko", LastName = "Markovic", Specialization = Specialization.CARDIOLOGY, Id = 1},
                     Patient = null,
                     Id = 1
             }, true},
              new object[]
             {
                 new Appointment {
                    StartTime = DateTime.Parse("1/5/2021 3:00:00 PM", System.Globalization.CultureInfo.InvariantCulture),
                    Doctor = new Doctor{ FirstName = "Marina", LastName = "Markovic", Specialization = Specialization.GENERAL_PRACTICE, Id = 2},
                    Patient = new Patient{ FirstName = "Petar", LastName = "Peric", Id = 1},
                    Id = 3
             }, false}
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void Checks_if_free_term(Appointment appointment, bool expected)
        {
            bool isFree = appointment.IsFree();
            Assert.Equal(expected, isFree);
        }
        

        [Fact]
        public void Checks_free_appointments_for_doctor()
        {
            // arrange
            var appointmentRequest = new AppointmentRequestDto
            {
                DoctorId = 1,
                From = DateTime.Parse("1/8/2021 8:30:00 AM", System.Globalization.CultureInfo.InvariantCulture),
                To = DateTime.Parse("1/10/2021 2:00:00 PM", System.Globalization.CultureInfo.InvariantCulture),
                DoctorIsPriority = true
            };

            // act
            _mockRepository.Setup(a => 
                a.Appointment.GetFreeAppointmentsForDoctor(appointmentRequest.From, appointmentRequest.To, appointmentRequest.DoctorId))
                .Returns(_freeAppointments);

            
            IActionResult actionResult = _appointmentController.GetAppointmentsForDoctor(appointmentRequest);
            var okResult = actionResult as OkObjectResult;
            var resultList = okResult.Value;

            // assert
            Assert.NotNull(okResult);
            
            Assert.Equal(_freeAppointments, resultList);

        }

    }
}
