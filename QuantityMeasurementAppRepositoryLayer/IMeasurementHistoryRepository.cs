using QuantityMeasurementAppModelLayer.Entity;
namespace QuantityMeasurementAppRepositoryLayer
{
    public interface IMeasurementHistoryRepository
    {
        public void SaveHistory(QuantityMeasurementHistoryEntity history);
    }
}