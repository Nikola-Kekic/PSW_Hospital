using Hospital.Controller;
using Hospital.Model;
using Hospital.Repository.Interfaces;
using Hospital.Service;
using Microsoft.AspNetCore.Mvc;
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

        public AuthTest()
        {
            _mockRepository = new Mock<IUnitOfWork>();
            _authService = new AuthService(_mockRepository.Object);
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

            OkObjectResult okResult = _authController.Login(loginRequest) as OkObjectResult;

            Assert.NotNull(okResult);
            Assert.IsType<string>((string)okResult.Value);
            // the result must not contain the given password
            Assert.DoesNotContain((string)okResult.Value, loginRequest.Password);

        }
    }
}

