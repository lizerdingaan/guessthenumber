
namespace ConsoleApp1
{
    using GameCore.Services;
    using System;

    public class RunGame
    {
        public int limit = 5;

        public int random;
        public Random rnd = new Random();
        public bool keepPlaying = true;
        public bool hasWon = false;
        public int score = 0;
        private readonly IUserInput _userInputService;

        public RunGame(IUserInput userInputService)
        {
            _userInputService = userInputService;
        }


        int GenerateRandomNumber()
        {
            int RandomNumber = rnd.Next(1, 21);
            return RandomNumber;
        }

        public void PrintMessage(String message)
        {
            Console.WriteLine(message);
        }

        public string Validate(int guess, int random)
        {
            if (guess < random)
            {
                limit--;
                return "Too low";
            }
            else if (guess > random)
            {
                limit--;
                return "Too high";
            }
            else
            {
                score++;
                hasWon = true;
                return "HOOOOOORRRAAAAYYYYYYY...Well done";
            }
        }

        public void PlayGame()
        {
            random = GenerateRandomNumber();
            while (keepPlaying & limit >= 0)
            {
                int guess = GetUserInput();
                String message = Validate(guess, random);
                PrintMessage(message); 
                if (hasWon)
                {
                    keepPlaying = ReplayGame();
                }
                if (limit == 0 & hasWon != true)
                {
                    PrintMessage("\nYou lose");
                    keepPlaying = ReplayGame();
                }
                PrintMessage("\nRemaining turns: " + limit);
            }
            PrintMessage("Your score is: " + score);
        }

        public bool ReplayGame()
        {
            Console.Write("Do you want to play again (y/n)? ");
            while (true)
            {
                var keyStroke = _userInputService.ReadKey(); 
                if (keyStroke.Key == ConsoleKey.Y)
                {
                    hasWon = false;
                    random = GenerateRandomNumber();
                    limit = 5;
                    return true;
                }
                else if (keyStroke.Key == ConsoleKey.N)
                {
                    return false;
                }
                else
                {
                    Console.Write("\nPlease input either y or n: ");
                }
            }
        }

        public int GetUserInput()
        {
            Console.Write("Input you guess: ");
            var UserGuess = _userInputService.ReadLine();
            int numValue;


            while (!int.TryParse(UserGuess, out numValue))
            {
                PrintMessage("Please enter a digit.");
                Console.Write("Input you guess: ");
                UserGuess = _userInputService.ReadLine();
            }
            return numValue;
        }


    }
}
