using GameCore.Models;

namespace GameCore.DTO
{
    public class ResponseDTO
    {
        public string Message { get; set; }

        public int Id { get; set; }

        public int Tries { get; set; }

        public bool PlayingGame { get; set; }
        public bool WonGame { get; set; }

        public List<GameInstance> games { get; set; }
    }
}
