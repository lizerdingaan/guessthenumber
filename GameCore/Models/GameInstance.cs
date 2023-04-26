using GameCore.Models;

namespace GameCore.Models
{
    public class GameInstance
    {
        public Guid Id { get; set; }
        public string UsernameId { get; set; } = null!;
        public int RandomNumber { get; set; }
        public int NumberOfTries { get; set; }
        public bool GameStatus { get; set; }
    }
}
