using GameCore.Models;

namespace GameCore.Models
{
    public class GameInstance
    {
        public int Id { get; set; }
        public string UsernameId { get; set; } = null!;
        public int RandomNumber { get; set; }
        public int NumberOfTries { get; set; }
        public string GameStatus { get; set; }
    }
}
