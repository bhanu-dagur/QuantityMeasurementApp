using Microsoft.EntityFrameworkCore;
using AuthService.Models;

namespace AuthService.Data
{
    // Database Context
    // It is used to connect to the database
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Users table
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Email should be unique
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}
