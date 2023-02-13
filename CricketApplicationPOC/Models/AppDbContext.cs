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

        DbSet<User> Users{ get; set;}
    }
}

