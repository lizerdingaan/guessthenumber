using GameCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCore.DTO
{
    public class GetHistoryDTO
    {
        public string Message { get; set; }

        List<GameInstance> gameInstances = new List<GameInstance>();
    }
}
