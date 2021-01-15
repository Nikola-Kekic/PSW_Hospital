using Hospital.Model;
using Hospital.Repository.Interfaces;
using Hospital.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Service
{
    public class UserService : IUserService
    {
        private IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public User CreateUser(User user)
        {
            var retVal = _unitOfWork.User.Create(user);
            _unitOfWork.Save();

            return retVal;
        }


        public IEnumerable<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public User GetUser(long id)
        {
            return _unitOfWork.User.GetUserById(id);
        }

        public void DeleteUser(long id)
        {
            var user = _unitOfWork.User.GetUserById(id);
            
            // if there are appointments with this user, delete them too
            foreach(Appointment a in _unitOfWork.Appointment.FindByCondition(x => x.User.Id.Equals(id)))
            {
                _unitOfWork.Appointment.Delete(a);
            }

            if (user != null)
                _unitOfWork.User.Delete(user);

            _unitOfWork.Save();
        }
    }
}
