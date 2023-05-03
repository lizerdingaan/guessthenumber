using GameCore.DTO;
using GameCore.Services;
using GameWebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;
using System.Net;
using System.Web;

namespace GameWebApiTest
{
    [TestClass]
    public class WebApiTests
    {
        private readonly GameStoringController _controller;
        private readonly ISingletonService _service;
        private string username;
        string getHistory = "y";
        string deleteHistory = "yes";
        string deleteUser = "delete";
        int id;
        int guess;

        public WebApiTests()
        {
            _controller = new GameStoringController(_service);
            //_service = service;
            
        }

        [TestMethod]
        public void StartGame_WhenCalled_PlayerStartsGame()
        {

            IActionResult actionResult = _controller.StartGame();
            OkObjectResult? okObjectResult = actionResult as OkObjectResult;
            ResponseDTO? responseDTO = (ResponseDTO)okObjectResult?.Value;

            responseDTO?.Message.Should().Be("Guess a number between 1 and 20. You have 5 tries");
            responseDTO?.Message.Should().BeOfType<string>();
        }

        [DataTestMethod]
        [DataRow("tshego")]
        public void UserExists_WhenCalled_ShouldValidateUsernameExists(string username)
        {
            IActionResult actionResult = _controller.UserExists(username);
            OkObjectResult okObjectResult = actionResult as OkObjectResult;
            AddUserDTO addUserDTO = (AddUserDTO)okObjectResult?.Value;

            addUserDTO.Message.Should().Be("\nThis username already exists.");
            addUserDTO.Message.Should().BeOfType<string>();
        }

        [DataTestMethod]
        [DataRow("none")]
        public void UserExits_WhenCalled_ShouldValidateUsernameDoesNotExist(string username)
        {
            IActionResult actionResult = _controller.UserExists(username);
            OkObjectResult okObjectResult = actionResult as OkObjectResult;
            AddUserDTO addUserDTO = (AddUserDTO)okObjectResult?.Value;

            addUserDTO.Message.Should().Be("\nThis username does not exist");
            addUserDTO.Message.Should().BeOfType<string>();
        }


        [DataTestMethod]
        [DataRow("tshego")]
        public void ValidateUsername_WhenCalled_ShouldNotRegisterUser(string username)
        {
            IActionResult actionResult = _controller.ValidateUsername(username);
            OkObjectResult okObjectResult = actionResult as OkObjectResult;
            AddUserDTO addUserDTO = (AddUserDTO)okObjectResult?.Value;

            addUserDTO?.Message.Should().Be("\nThis username already exists. Please think of a more unique username.");
            addUserDTO?.Message.Should().BeOfType<string>();
        }

        [TestMethod]
        public void StartGame_WhenCalled_ReturnsOkResult()
        {
            //Act
            int Id = _service.AddNew();
            var okResult = _controller.StartGame();

            //Assert
            Assert.IsInstanceOfType(okResult, typeof(OkObjectResult));
        }

        [TestMethod]
        public void UserExists_WhenCalled_ReturnsOkResult()
        {
            //Act
            var okResult = _controller.UserExists(username);

            //Assert
            Assert.IsInstanceOfType(okResult, typeof(OkObjectResult));
        }

        [TestMethod]
        public void ValidateUsername_WhenCalled_ReturnsOkResult()
        {
            //Act
            var okResult = _controller.ValidateUsername(username);

            //Assert
            Assert.IsInstanceOfType(okResult, typeof(OkObjectResult));

        }

        [TestMethod]
        public void GetGameHistory_WhenCalled_ReturnsOkResult()
        {
            //Act
            var okResult = _controller.GetGameHistory(getHistory, username);

            //Assert
            Assert.IsInstanceOfType(okResult, typeof(OkObjectResult));
        }

        [TestMethod]
        public void DeleteHistory_WhenCalled_ReturnsOkResult()
        {
            //Act
            var okResult = _controller.DeleteHistory(deleteHistory, username);

            //Assert
            Assert.IsInstanceOfType(okResult, typeof(OkObjectResult));
        }

        [TestMethod]
        public void DeleteUser_WhenCalled_ReturnsOkResult()
        {
            //Act
            var okResult = _controller.DeleteUser(deleteUser, username);

            //Assert
            Assert.IsInstanceOfType(okResult, typeof(OkObjectResult));
        }

        [TestMethod]
        public void Guess_WhenCalled_ReturnsOkResult()
        {
            //Act
            var okResult = _controller.Guess(username, id, guess);

            //Assert
            Assert.IsInstanceOfType(okResult, typeof(OkObjectResult));
        }
    }
}