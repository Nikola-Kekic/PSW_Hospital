using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Repository.Interfaces
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(long Id);
        User GetUserWithDetails(long Id);
        void DeleteUser(User patient);
    
    }
}
