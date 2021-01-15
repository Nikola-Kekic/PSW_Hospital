using Hospital.Context;
using Hospital.Model;
using Hospital.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(HospitalContext context) : base(context)
        {
        }

        public IEnumerable<User> GetAllUsers()
        {
            return FindAll()
                .OrderBy(a => a.Id)
                .ToList();
        }

        public User GetUserById(long Id)
        {
            return FindByCondition(t => t.Id.Equals(Id))
                .FirstOrDefault();
        }

        public User GetUserWithDetails(long Id)
        {
            return FindByCondition(a => a.Id.Equals(Id))
                .FirstOrDefault();
        }

        public void DeleteUser(User patient)
        {
            Delete(patient);
        }


    }
}

