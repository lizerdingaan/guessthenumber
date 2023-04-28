

using GameCore.DTO;
using System.Reflection.Metadata;

namespace GameCore.Services
{
    // Singleton service creates a single
    // instance once and reuses the same object in all calls.
    [Obsolete]
    public class SingletonService_LEGACY
    {
        public List<GameInstanceDTO> game = new List<GameInstanceDTO>();
        GameInstanceDTO userGame = new GameInstanceDTO();



        private int numberToGuess = new Random().Next(1, 21);

        private int remainingGuesses = 5;

        public void Users()
        {
            int user_id = 0;
            game.Add(new GameInstanceDTO { UserId=user_id, RandomNumber=numberToGuess, RemainingGuesses=remainingGuesses });
        }
        public SingletonService_LEGACY()
        {
            Users();
        }

        public void Init()
        {
            
            userGame.RandomNumber = new Random().Next(1, 21);
            userGame.RemainingGuesses = 5;

            StatusUpdate();
        }

        public bool Guess(int guess)
        {

            if (userGame.RemainingGuesses <= 0)
            {
                throw new Exception("You are out of guesses!!!");
            }

            if (guess == userGame.RandomNumber)
            {
                return true; 
            }

            --userGame.RemainingGuesses;

            StatusUpdate();

            return false;
        }



        private void StatusUpdate()
        {
            Console.WriteLine($"Number to guess {userGame.RandomNumber}");
            Console.WriteLine($"Remaining guesses {userGame.RemainingGuesses}");
        }

    }
}
