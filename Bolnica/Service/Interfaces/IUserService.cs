using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Service.Interfaces
{
    public interface IUserService
    {
        public IEnumerable<User> GetAllUsers();
        public User GetUser(long id);
        public User CreateUser(User patient);
        public void DeleteUser(long id);
    }
}
