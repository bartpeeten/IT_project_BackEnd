using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using KBVB.API.Controllers;
using KBVB.API.Entities;
using KBVB.API.Interfaces;
using KBVB.API.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace KBVB.API.Unittests
{
    [TestFixture]
    public class PlayerControllerTest
    {
        private Mock<IPlayerRepository> playerRepoMock;
        private List<Player> dummyPlayers;
        private PlayerController controller;

        [SetUp]
        public void SetUp()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Player, PlayerDto>();
            });
            playerRepoMock = new Mock<IPlayerRepository>();
            dummyPlayers = new List<Player>
            {
                new Player()
                {
                    Id          = Guid.NewGuid(),
                    FirstName   = "Test",
                    LastName    = "Test",
                    CurrentTeam = "Test",
                    DidYouKnow  = "Test",
                    ImageURL    = "Test"
                },
                new Player()
                {
                    Id          = Guid.NewGuid(),
                    FirstName   = "Test1",
                    LastName    = "Test1",
                    CurrentTeam = "Test1",
                    DidYouKnow  = "Test1",
                    ImageURL    = "Test1"
                }
            };
            
        }

        [Test]
        public void GetPlayerShouldReturnAllPlayersFromDb()
        {
            //Arrange
            playerRepoMock.Setup(r => r.GetPlayers()).Returns(() => dummyPlayers);
            controller = new PlayerController(playerRepoMock.Object);

            //Act
            var actionResult = controller.Get() as OkObjectResult;
            var expectedPlayers = Mapper.Map<List<PlayerDto>>(dummyPlayers);
            var result = actionResult.Value as List<PlayerDto>;

            //Assert
            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOf<OkObjectResult>(actionResult);
            for(int i = 0; i < result.Count(); i++)
            {
                Assert.That(result[i].Id, Is.EqualTo(expectedPlayers[i].Id));
                Assert.That(result[i], Is.TypeOf<PlayerDto>());
            }
        }

        [Test]
        public void GetPlayerShouldReturnNotFoundWhenNoPlayersWhereFound()
        {
            //Arrange
            playerRepoMock.Setup(r => r.GetPlayers()).Returns(() => new List<Player>());
            controller = new PlayerController(playerRepoMock.Object);

            //Act
            var actionResult = controller.Get() as ActionResult;

            //Assert
            Assert.IsInstanceOf<NotFoundResult>(actionResult);
        }
    }
}