using QuantityMeasurementAppModelLayer.Entity;
namespace QuantityMeasurementAppRepositoryLayer
{
    public interface IMeasurementHistoryRepository
    {
        public void SaveHistory(QuantityMeasurementHistoryEntity history);
        public void SaveUser(User user);
        public User GetUserByEmail(string email);
    }
}