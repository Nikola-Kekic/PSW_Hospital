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
using System.Linq;

namespace HospitalTests
{
    public class AppointmentTest
    {
        /* Snake case notation necessary */

        private AppointmentController _appointmentController;
        private IAppointmentService _appointmentService;

        private Mock<IUnitOfWork> _mockRepository;
        private Mock<IAppointmentService> _mockService;

        private static AppointmentRequestDto _appointmentRequest => new AppointmentRequestDto
        {
            DoctorId = 1,
            From = DateTime.Parse("1/10/2021 8:30:00 AM", System.Globalization.CultureInfo.InvariantCulture),
            To = DateTime.Parse("1/13/2021 2:00:00 PM", System.Globalization.CultureInfo.InvariantCulture),
            DoctorIsPriority = true
        };


        private static IList<Appointment> _freeAppointments => new List<Appointment>
        {
            new Appointment {
                StartTime = DateTime.Parse("1/9/2021 9:30:00 AM", System.Globalization.CultureInfo.InvariantCulture),
                Doctor = new Doctor{ FirstName = "Marko", LastName = "Markovic", Specialization = Specialization.CARDIOLOGY, Id = 2},
                User = null,
                Id = 1
            },
            new Appointment {
                StartTime = DateTime.Parse("1/12/2021 3:00:00 PM", System.Globalization.CultureInfo.InvariantCulture),
                Doctor = new Doctor{ FirstName = "Marina", LastName = "Markovic", Specialization = Specialization.GENERAL_PRACTICE, Id = 3},
                User = null,
                Id = 2
            } 
        };

        private static IList<Appointment> _takenAppointments => new List<Appointment>
        {
            new Appointment {
                StartTime = DateTime.Parse("1/10/2021 3:00:00 PM", System.Globalization.CultureInfo.InvariantCulture),
                Doctor = new Doctor{ FirstName = "Marina", LastName = "Markovic", Specialization = Specialization.GENERAL_PRACTICE, Id = 3},
                User = new User{ FirstName = "Petar", LastName = "Peric", Id = 1},
                Id = 3
            }
        };

        public static IEnumerable<object[]> Data => new List<object[]>
        {
            new object[] { GetFreeAppointment(0), true },
            new object[] { GetFreeAppointment(1), true },
            new object[] { GetTakenAppointment(0), false }
        };

      
        public static IEnumerable<object[]> DataWithDto => new List<object[]>
        {
            new object[] { GetFreeAppointment(0), getAppointmentRequest(), true },
            new object[] { GetFreeAppointment(1), getAppointmentRequest(), false }
        };

        private static object getAppointmentRequest()
        {
            return _appointmentRequest;
        }

        private static object GetFreeAppointment(int i)
        {
            return _freeAppointments[i];
        }
        private static object GetTakenAppointment(int i)
        {
            return _takenAppointments[i];
        }

        public AppointmentTest()
        {
            _mockRepository = new Mock<IUnitOfWork>();
            _mockService = new Mock<IAppointmentService>();
            _appointmentController = new AppointmentController(_mockRepository.Object, _mockService.Object);
            _appointmentService = new AppointmentService(_mockRepository.Object);

        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Checks_if_free_appointment(Appointment appointment, bool expected)
        {
            bool isFree = appointment.IsFree();
            Assert.Equal(expected, isFree);
        }

        [Theory]
        [MemberData(nameof(DataWithDto))]
        public void Checks_if_appointment_in_period(Appointment appointment, AppointmentRequestDto request, bool expected)
        {
            bool fits = _appointmentService.isAppointemntInPeriod(appointment, request.From, request.To);
            Assert.Equal(expected, fits);
        }

        [Fact]
        public void Checks_free_appointments_for_doctor()
        {
            var allAppointments = _freeAppointments.Concat(_takenAppointments).ToList();
            var freeForThirdDoctor = _freeAppointments.Where(x => x.Doctor.Id.Equals(3)).ToList();

            _mockRepository.Setup(a =>
                a.Appointment.GetAppointmentsForDoctor(_appointmentRequest.DoctorId))
                .Returns(allAppointments.Where(x => x.Doctor.Id.Equals(3)).ToList());


            //IActionResult actionResult = _appointmentController.GetAppointmentsForDoctor(_appointmentRequest);
            //var okResult = actionResult as OkObjectResult;
            //var resultList = okResult.Value;

            //Assert.NotNull(okResult);
            //Assert.Equal(_freeAppointments, resultList);

            var result = _appointmentService.GetAppointmentRecommendations(_appointmentRequest);
            
            Assert.NotNull(result);
            Assert.Equal(freeForThirdDoctor.Count, result.ToList().Count);
            Assert.Collection(freeForThirdDoctor, a1 => Assert.Equal(result.ElementAt(0).Id, a1.Id));
        }

    }
}
