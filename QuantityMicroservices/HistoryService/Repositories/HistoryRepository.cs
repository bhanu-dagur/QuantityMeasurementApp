using HistoryService.Data;
using HistoryService.Models;
using Microsoft.EntityFrameworkCore;

namespace HistoryService.Repositories
{
    public interface IHistoryRepository
    {
        Task SaveAsync(MeasurementHistory history);
        Task<List<MeasurementHistory>> GetByUserIdAsync(string userId);
    }

    public class HistoryRepository : IHistoryRepository
    {
        private readonly AppDbContext _db;

        public HistoryRepository(AppDbContext db)
        {
            _db = db;
        }

        // Naya record save karo
        public async Task SaveAsync(MeasurementHistory history)
        {
            _db.MeasurementHistories.Add(history);
            await _db.SaveChangesAsync();
        }

        // Ek user ki saari history lao (naya pehle)
        public async Task<List<MeasurementHistory>> GetByUserIdAsync(string userId)
        {
            return await _db.MeasurementHistories
                .Where(h => h.UserId == userId)
                .OrderByDescending(h => h.CreatedAt)
                .ToListAsync();
        }
    }
}
