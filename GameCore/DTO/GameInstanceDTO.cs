using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCore.DTO
{
    public class GameInstanceDTO
    {
        
        public Guid UserId { get; set; }
        
        public int RandomNumber { get; set; }

        public int RemainingGuesses { get; set; }

    }

}
