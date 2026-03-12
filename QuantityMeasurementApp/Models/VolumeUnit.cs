namespace QuantityMeasurementApp.Models
{
    public enum VolumeUnit
    {
        LITRE,
        MILLILITRE,
        GALLON
    }

    public static class VolumeUnitExtension
    {
        public static double GetConversionFactor(this VolumeUnit unit)
        {
            return unit switch
            {
                VolumeUnit.LITRE => 1.0,
                VolumeUnit.MILLILITRE => 0.001,
                VolumeUnit.GALLON => 3.78541,
                _ => throw new ArgumentException("Invalid Volume Unit")
            };
        }

        public static double ConvertToBaseUnit(this VolumeUnit unit, double value)
        {
            return value * unit.GetConversionFactor();
        }

        public static double ConvertFromBaseUnit(this VolumeUnit unit, double baseValue)
        {
            return baseValue / unit.GetConversionFactor();
        }

        public static string GetUnitName(this VolumeUnit unit)
        {
            return unit.ToString();
        }
        public static bool SupportsArithmetic(this VolumeUnit unit)
        {
            return true;
        }

        public static void ValidateOperationSupport(this VolumeUnit unit, string operation)
        {
            if (!SupportsArithmetic(unit))
            throw new UnsupportedOperationException(
                $"Temperature does not support {operation} operation.");
        }
    }
}