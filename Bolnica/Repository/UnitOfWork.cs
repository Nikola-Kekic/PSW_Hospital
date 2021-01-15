﻿using Hospital.Context;
using Hospital.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private HospitalContext context;
        private AppointmentRepository appointment;
        private DoctorRepository doctor;
        private UserRepository user;

        private bool disposed = false;

        public UnitOfWork(HospitalContext hospitalContext)
        {
            context = hospitalContext;
        }

        public IAppointmentRepository Appointment
        {
            get
            {
                if (appointment == null)
                {
                    appointment = new AppointmentRepository(context);
                }
                return appointment;
            }
        }
        public IDoctorRepository Doctor
        {
            get
            {
                if (doctor == null)
                {
                    doctor = new DoctorRepository(context);
                }
                return doctor;
            }
        }

        public IUserRepository User
        {
            get
            {
                if (user == null)
                {
                    user = new UserRepository(context);
                }
                return user;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
