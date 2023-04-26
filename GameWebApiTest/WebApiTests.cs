using GameCore.Services;
using GameWebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
        Guid id;
        int guess;

        public WebApiTests()
        {
            _controller = new GameStoringController(_service);
            
        }
        [TestMethod]
        public void StartGame_WhenCalled_ReturnsOkResult()
        {
            //Act
            Guid Id = _service.AddNew();
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