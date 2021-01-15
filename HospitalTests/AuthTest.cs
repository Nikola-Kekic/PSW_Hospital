using Hospital.Controller;
using Hospital.Model;
using Hospital.Repository.Interfaces;
using Hospital.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HospitalTests
{
    public class AuthTest
    {
        private Mock<IUnitOfWork> _mockRepository;
        private AuthController _authController;
        private AuthService _authService;

        private IConfiguration _configuration;

        public AuthTest(IConfiguration Configuration)
        {
            _configuration = Configuration;

            _mockRepository = new Mock<IUnitOfWork>();
            _authService = new AuthService(_mockRepository.Object, _configuration);
            _authController = new AuthController(_authService);
        }

        [Fact]
        public void Checks_login()
        {
            var loginRequest = new LoginRequest
            {
                Email = "test@test.rs",
                Password = "pass123"
            };

            User existing = new User { Email = "test@test.rs", Password = "pass123" };
            List<User> mockDatabase = new List<User>();
            mockDatabase.Add(existing);

            _mockRepository.Setup(a => a.User.GetAllUsers()).Returns(mockDatabase);

            OkObjectResult okResult = _authController.Login(loginRequest) as OkObjectResult;

            Assert.NotNull(okResult);
            Assert.IsType<string>((string)okResult.Value);
            // the result must not contain the given password
            Assert.DoesNotContain((string)okResult.Value, loginRequest.Password);

        }

        [Fact]
        public void Checks_login_user_does_not_exist()
        {
            var loginRequest = new LoginRequest
            {
                Email = "test@test.rs",
                Password = "pass123"
            };
            
            _mockRepository.Setup(a =>  a.User.GetAllUsers()).Returns(new List<User>());

            var result = _authController.Login(loginRequest);

            Assert.NotNull(result);
            Assert.IsType<BadRequestResult>(result);

        }
    }
}

