﻿using Hospital.Context;
using Hospital.Model;
using Hospital.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Repository
{
    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(HospitalContext context) : base(context)
        {
        }

        public IEnumerable<Doctor> GetAllDoctors()
        {
            return FindAll()
                .OrderBy(a => a.Id)
                .ToList();
        }

        public Doctor GetDoctorById(long Id)
        {
            return FindByCondition(t => t.Id.Equals(Id))
                .FirstOrDefault();
        }

        public Doctor GetDoctorWithDetails(long Id)
        {
            return FindByCondition(a => a.Id.Equals(Id))
                .FirstOrDefault();
        }

        public void DeleteDoctor(Doctor doctor)
        {
            Delete(doctor);
        }


    }
}
