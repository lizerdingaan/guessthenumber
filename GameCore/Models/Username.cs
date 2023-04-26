using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCore.Models
{
    [Index(nameof(Name))]
    public class Username
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
