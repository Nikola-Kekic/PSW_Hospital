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

namespace HospitalTests
{
    public class AppointmentTest
    {
        /* Snake case notation necessary */

        private AppointmentController _appointmentController;
        private Mock<IUnitOfWork> _mockRepository;
        private IList<Appointment> _freeAppointments;


        public AppointmentTest()
        {
            Seed();

            _mockRepository = new Mock<IUnitOfWork>();
            _appointmentController = new AppointmentController(_mockRepository.Object);

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

        [Fact]
        //[MemberData(nameof(Data))]
        public void Checks_free_appointments_for_doctor()
        {
            // arrange
            var appointmentRequest = new AppointmentRequestDto
            {
                DoctorId = 1,
                From = DateTime.Parse("1/8/2021 8:30:00 AM", System.Globalization.CultureInfo.InvariantCulture),
                To = DateTime.Parse("1/10/2021 2:00:00 PM", System.Globalization.CultureInfo.InvariantCulture)
            };

            // act
            _mockRepository.Setup(a => 
                a.Appointment.GetFreeAppointmentsForDoctor(appointmentRequest.From, appointmentRequest.To, appointmentRequest.DoctorId))
                .Returns(_freeAppointments);

            ActionResult result = _appointmentController.GetAppointmentsForDoctor(appointmentRequest);

            // assert
            Assert.NotNull(result);
            Assert.Equal(_freeAppointments, ((ViewResult)result).Model);

        }

    }
}
