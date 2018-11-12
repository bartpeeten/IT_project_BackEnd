using AutoMapper;
using KBVB.API.Controllers;
using KBVB.API.Entities;
using KBVB.API.Interfaces;
using KBVB.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace KBVB.API.Unittests

{   [TestFixture]
    public class UserControllerTest
    {
        private Mock<IUserRepository> userRepoMock;
        private User dummyUser;
        private UserController controller;

        public UserControllerTest()
        {

        }

        [SetUp]
        public void SetUp()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<User, UserDto>();
            });
            userRepoMock = new Mock<IUserRepository>();
            dummyUser = new User
            {
                Id = new Guid("feae9389-4646-4d29-c5b2-386fff92ce36"),
                FirstName = "Test",
                LastName = "User",
                DateOfBirth = new DateTime(1980, 10, 10),
                Email = "dummy@test.com",
                Password = ""
            };
        }

        [Test]
        [TestCase("dummy@test.com")]
        public void GetUserShouldReturnRequestedUserByEmailFromDb(string email)
        {
            //Arrange
            userRepoMock.Setup(r => r.GetUser(email)).Returns(() => dummyUser);
            controller = new UserController(userRepoMock.Object);
            //Act
            var actionResult = controller.Get(email) as OkObjectResult;
            var expectedUser = Mapper.Map<UserDto>(dummyUser);
            var result = actionResult.Value as UserDto;

            //Assert
            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOf<OkObjectResult>(actionResult);
            Assert.That(result.Id, Is.EqualTo(expectedUser.Id));
        }

        [Test]
        [TestCase("dummy@test.com")]
        public void GetUserShouldReturnNotFoundWhenEmailIsNotFound(string email)
        {
            //Arrange
            userRepoMock.Setup(r => r.GetUser(email)).Returns(() => null);
            controller = new UserController(userRepoMock.Object);
            //Act
            var actionResult = controller.Get(email) as ActionResult;
            //Assert
            Assert.IsInstanceOf<NotFoundResult>(actionResult);

        }
    }
}
