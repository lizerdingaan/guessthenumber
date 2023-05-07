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
        string deleteHistory = "yes";
        string deleteUser = "delete";

        public WebApiTests()
        {
            _controller = new GameStoringController(_service);
            
        }


        [TestMethod]
        public void UserExists_WhenCalled_ReturnsOkResult()
        {
            // act
            var okResult = _controller.UserExists(username);

            // assert
            Assert.IsInstanceOfType(okResult, typeof(OkObjectResult));
        }


        [DataTestMethod]
        [DataRow("tshego")]
        public void UserExists_WhenCalled_ShouldValidateUsernameExists(string username)
        {
            // arrange
            IActionResult actionResult = _controller.UserExists(username);

            //act
            OkObjectResult okObjectResult = actionResult as OkObjectResult;
            AddUserDTO addUserDTO = (AddUserDTO)okObjectResult?.Value;

            // assert
            addUserDTO.Message.Should().Be("\nThis username already exists.");
            addUserDTO.Message.Should().BeOfType<string>();
        }

        [DataTestMethod]
        [DataRow("none")]
        public void UserExits_WhenCalled_ShouldValidateUsernameDoesNotExist(string username)
        {
            // arrange
            IActionResult actionResult = _controller.UserExists(username);

            // act
            OkObjectResult okObjectResult = actionResult as OkObjectResult;
            AddUserDTO addUserDTO = (AddUserDTO)okObjectResult?.Value;

            // assert
            addUserDTO.Message.Should().Be("\nThis username does not exist");
            addUserDTO.Message.Should().BeOfType<string>();
        }


        [DataTestMethod]
        [DataRow("tshego")]
        public void ValidateUsername_WhenCalled_ShouldNotRegisterUser(string username)
        {
            // arrange
            IActionResult actionResult = _controller.ValidateUsername(username);

            // act
            OkObjectResult okObjectResult = actionResult as OkObjectResult;
            AddUserDTO addUserDTO = (AddUserDTO)okObjectResult?.Value;

            // assert
            addUserDTO?.Message.Should().Be("\nThis username already exists. Please think of a more unique username.");
            addUserDTO?.Message.Should().BeOfType<string>();
        }


        [DataTestMethod]
        [DataRow("none")]
        public void ValidateUsername_WhenCalled_ShouldRegisterNewUser(string username)
        {
            // arrange
            IActionResult actionResult = _controller.ValidateUsername(username);

            // act
            OkObjectResult okObjectResult = actionResult as OkObjectResult;
            AddUserDTO addUserDTO = (AddUserDTO)okObjectResult?.Value;

            // assert
            addUserDTO?.Message.Should().Be($"Hi, {username} you have been registered. Good luck!");
            addUserDTO?.Message.Should().BeOfType<string>();
        }


        [DataTestMethod]
        [DataRow("y")]
        [DataRow("tshego")]
        public void GetGameHistory_CalledWithExistingUser_ShouldReturnPreviousGames(string history, string username)
        {
            IActionResult actionResult = _controller.GetGameHistory(history, username);
            OkObjectResult okObjectResult = actionResult as OkObjectResult;
            ResponseDTO responseDto = (ResponseDTO)okObjectResult?.Value;

            responseDto?.Message.Should().Be($"{username}'s previous games.");
            responseDto?.Message.Should().BeOfType<string>();
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

    }
}