using GameCore.DTO;

namespace GameCore.Services
{
    public class SingletonService : ISingletonService

    {

        private readonly List<GameInstanceDTO> _gameList;

        public SingletonService()
        {
            _gameList = new List<GameInstanceDTO>();
        }

        GameInstanceDTO gameInstance = new GameInstanceDTO();

        public int AddNew()
        {
            var newUser = new GameInstanceDTO { UserId = 0, RandomNumber = new Random().Next(1, 21), RemainingGuesses = 5 };
            _gameList.Add(newUser);

            return newUser.UserId;

        }


        public int GetGuess(Guid id)
        {
            return _gameList.First(gameInstance => gameInstance.UserId.Equals(id)).RandomNumber;
        }


        public int DecrementNumberOfTries(Guid id)
        {
           
            return _gameList.First(gameInstance => gameInstance.UserId.Equals(id)).RemainingGuesses--;
        }


        public int NumberOfTriesLeft(Guid id)
        {
            return _gameList.First(gameInstance => gameInstance.UserId.Equals(id)).RemainingGuesses;
        }

       
        public bool Guess(int guess, Guid id)
        {

            if (_gameList.First(gameInstance => gameInstance.UserId.Equals(id)).RemainingGuesses <= 1)
            {
                throw new Exception("You are out of guesses!!!");
            }

            if (guess == gameInstance.RandomNumber)
            {
                return true;
            }

            DecrementNumberOfTries(id);

            return false;
        }

        public int DecrementNumberOfTries(int id)
        {
            throw new NotImplementedException();
        }

        public int NumberOfTriesLeft(int id)
        {
            throw new NotImplementedException();
        }

        public bool Guess(int guess, int id)
        {
            throw new NotImplementedException();
        }

        public int GetGuess(int id)
        {
            throw new NotImplementedException();
        }
    }
}
