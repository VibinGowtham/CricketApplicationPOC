using System;
using Microsoft.EntityFrameworkCore;

namespace NotificationApiService.Models
{
	public class AppDbContext : DbContext
	{
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions options) :base(options)
        {
		}

        public virtual DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Notification>().ToTable(nameof(Notifications), t => t.ExcludeFromMigrations());
        }
    }
}

