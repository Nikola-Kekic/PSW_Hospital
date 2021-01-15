using Hospital.Dto;
using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Adapter
{
    public class UserAdapter
    {
        public static User UserDtoToUser(UserDto dto)
        {
            User user = new User();
            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.Email = dto.Email;
            user.Address = dto.Address;
            user.PhoneNumber = dto.PhoneNumber;
            user.Password = dto.Password;
            user.Role = dto.Role;

            return user;
        }

        public static UserDto UserToUserDto(User user)
        {
            UserDto dto = new UserDto();
            dto.FirstName = user.FirstName;
            dto.LastName = user.LastName;
            dto.Email = user.Email;
            dto.Address = user.Address;
            dto.PhoneNumber = user.PhoneNumber;
           
            return dto;
        }
    }
}
