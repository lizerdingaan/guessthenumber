global using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp1;
using GameCore.Services;
using FluentAssertions;
using NSubstitute;

namespace ConsoleApp1Tests   
{

    [TestClass]
    public class RunGameTests
    {
        [TestMethod]
        public void Validate_WhenGuessIsLower_ShouldReturnTooLow()
        {
            //Arrange
            int guess = 0;
            int random = 7;

            //Act
            var userInputService = new ConsoleUserInput();
            RunGame run = new RunGame(userInputService);
            string validation = run.Validate(guess, random);

            //Assert
            Assert.AreEqual(validation, "Too low");

        }

        [TestMethod]
        public void Validate_WhenGuessIsHigher_ShouldReturnTooHigh()
        {
            //Arrange
            int guess = 5;
            int random = 1;

            //Act
            var userInputService = new ConsoleUserInput();
            RunGame run = new RunGame(userInputService);
            string validation = run.Validate(guess, random);

            //Assert
            Assert.AreEqual(validation, "Too high");

        }

        [TestMethod]

        public void Validate_WhenGuessIsEqualToRandom_ShouldReturnAWin()
        {
            //Arrange
            int guess = 20;
            int random = 20;

            //Act
            var userInputService = new ConsoleUserInput();
            RunGame run = new RunGame(userInputService);
            string validation = run.Validate(guess, random);

            //Assert
            Assert.AreEqual(validation, "HOOOOOORRRAAAAYYYYYYY...Well done");
        }



        [DataTestMethod]
        [DataRow("12")]
        public void GetUserInput_WhenGivenAString_ShouldReturnAnInteger(string input)
        {
            //Arrange
            var substitute = Substitute.For<IUserInput>();

            //Act
            var stdin = substitute.ReadLine().Returns("12").ToString();
            RunGame run = new RunGame(substitute);
            int actual = run.GetUserInput();

            //Assert

            Assert.AreEqual(int.Parse(input), actual);
            stdin.Should().BeOfType<string>();

        }

        [TestMethod]

        public void ReplayGame_WhenGivenNo_ShouldReturnFalse()
        {
            //Arrange
            var substitute = Substitute.For<IUserInput>();
            RunGame running = new RunGame(substitute);
            var userKey = substitute.ReadKey().Returns(new ConsoleKeyInfo('n', ConsoleKey.N, false, false, false));

            //Act
            bool key = running.ReplayGame();

            //Assert
            Assert.AreEqual(false, key);
            key.Should().BeFalse();
        }

        [TestMethod]

        public void ReplayGame_WhenGivenYes_ShouldReturnTrue()
        {
            //Arrange
            var substitute = Substitute.For<IUserInput>();
            RunGame run = new RunGame(substitute);
            substitute.ReadKey().Returns(new ConsoleKeyInfo('y', ConsoleKey.Y, false, false, false));

            //Act
            bool key = run.ReplayGame();

            //Assert
            Assert.AreEqual(true, key);
            key.Should().BeTrue();
        }


    }


}
