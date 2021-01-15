﻿using Hospital.Dto;
using Hospital.Model;
using Hospital.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Service
{
    public class AppointmentService : IAppointmentService
    {
        private IUnitOfWork _unitOfWork;

        public AppointmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Appointment> GetAppointments()
        {
            List<Appointment> appointments = _unitOfWork.Appointment.GetAllAppointments().ToList();

            foreach(Appointment a in appointments)
            {
               // a.Doctor = _unitOfWork.Doctor.GetDoctorById(a.)
            }

            return appointments;
        }

        public IEnumerable<Appointment> GetAppointmentRecommendations(AppointmentRequestDto dto)
        {
            List<Appointment> freeAppointments = new List<Appointment>();

            var appointments = _unitOfWork.Appointment.GetAppointmentsForDoctor(dto.DoctorId).ToList();

            foreach(Appointment a in appointments)
            {
                if (a.IsFree() && isAppointemntInPeriod(a, dto.From, dto.To))
                {
                    freeAppointments.Add(a);
                }
            }

            return freeAppointments;
        }

        public Appointment GetAppointment(long id)
        {
            return _unitOfWork.Appointment.GetAppointmentById(id);
        }

        public Appointment CreateAppointment(Appointment appointment, Doctor doctor)
        {
            appointment.Doctor = doctor;
            var retVal = _unitOfWork.Appointment.Create(appointment);
            _unitOfWork.Save();
            return retVal;
        }


        // da li je bolje ovo u repozitorijumu
        public bool isAppointemntInPeriod(Appointment a, DateTime start, DateTime end)
        {
            return a.StartTime > start && a.StartTime < end;
        }

    }
}
