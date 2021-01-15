using Hospital.Adapter;
using Hospital.Dto;
using Hospital.Model;
using Hospital.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Controller
{
    [Authorize (Roles = "ADMIN")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/User
        [HttpGet]
        public ActionResult GetUsers()
        {
            return Ok(_userService.GetAllUsers().ToList());
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public ActionResult GetUser(long id)
        {
            var user = _userService.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // POST: api/User
        [HttpPost]
        public ActionResult CreateUser(UserDto dto)
        {
            User user = UserAdapter.UserDtoToUser(dto);

            user = _userService.CreateUser(user);

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        // DELETE: api/User
        [HttpDelete("{id}")]
        public ActionResult DeleteUser(long id)
        {
            _userService.DeleteUser(id);

            return NoContent();
        }

    }
}
