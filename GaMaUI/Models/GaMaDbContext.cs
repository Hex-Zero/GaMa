using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GaMaUI.Models
{
    class GaMaDbContext : DbContext
    {
        public GaMaDbContext(DbContextOptions options) : base(options) { }
        public DbSet<GameManager> GameManagers { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Venue> Venues{ get; set; }
    }
}
