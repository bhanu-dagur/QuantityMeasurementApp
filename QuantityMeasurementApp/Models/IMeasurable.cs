namespace QuantityMeasurementApp.Models
{
    public interface IMeasurable
    {
        double GetConversionFactor();

        double ConvertToBaseUnit(double value);

        double ConvertFromBaseUnit(double baseValue);

        string GetUnitName();

        //  UC14 new functional interface support
        bool SupportsArithmetic()
        {
            return true;
        }

        //  UC14 operation validation
        void ValidateOperationSupport(string operation)
        {
            if (!SupportsArithmetic())
            {
                throw new UnsupportedOperationException(
                    $"{GetUnitName()} does not support {operation} operation.");
            }
        }
    }

    public class UnsupportedOperationException : Exception
    {
        public UnsupportedOperationException(string message) : base(message) { }
    }
}