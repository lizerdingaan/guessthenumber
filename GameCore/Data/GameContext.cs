using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCore.Models;

namespace GameCore.Data
{
    public class GameContext : DbContext
    {
        public DbSet<GameInstance> GameInstances { get; set; }

        public DbSet<Username> Usernames { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Username>().Property(n => n.Name).UseCollation("SQL_Latin1_General_CP1_CS_AS");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=GameCore;Trusted_Connection=True;");
        }

    }
}
