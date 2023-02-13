using System;
using Microsoft.EntityFrameworkCore;

namespace CricketApplicationPOC.Models
{
	public class AppDbContext : DbContext
	{
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions options) :base(options)
        {
		}

        public DbSet<User> Users{ get; set;}

        public DbSet<Player> Players { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<PlayerStatistics> PlayerStatistics { get; set; }

        public DbSet<Match> Matches { get; set; }
    }
}

