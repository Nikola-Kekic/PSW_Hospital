using Hospital.Dto;
using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hospital.Service
{
    public interface IAppointmentService
    {
        IEnumerable<Appointment> GetAppointmentRecommendations(AppointmentRequestDto dto);
        bool isAppointemntInPeriod(Appointment a, DateTime start, DateTime end);
    }
}
