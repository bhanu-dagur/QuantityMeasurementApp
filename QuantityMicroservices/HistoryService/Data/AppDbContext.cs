using HistoryService.Models;
using Microsoft.EntityFrameworkCore;

namespace HistoryService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // MeasurementHistory table
        public DbSet<MeasurementHistory> MeasurementHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MeasurementHistory>().ToTable("MeasurementHistory");
            base.OnModelCreating(modelBuilder);
        }
    }
}
