namespace QuantityMeasurementApp.Models
{
    public enum WeightUnit
    {
        KILOGRAM,
        GRAM
    }

    public static class WeightUnitExtension
    {
        public static double GetConversionFactor(this WeightUnit unit)
        {
            return unit switch
            {
                WeightUnit.KILOGRAM => 1.0,
                WeightUnit.GRAM => 0.001,
                _ => throw new ArgumentException("Invalid Weight Unit")
            };
        }

        public static double ConvertToBaseUnit(this WeightUnit unit, double value)
        {
            return value * unit.GetConversionFactor();
        }

        public static double ConvertFromBaseUnit(this WeightUnit unit, double baseValue)
        {
            return baseValue / unit.GetConversionFactor();
        }

        public static string GetUnitName(this WeightUnit unit)
        {
            return unit.ToString();
        }
        public static bool SupportsArithmetic(this WeightUnit unit)
        {
            return true;
        }

        public static void ValidateOperationSupport(this WeightUnit unit, string operation)
        {
            if (!SupportsArithmetic(unit))
            throw new UnsupportedOperationException(
                $"Temperature does not support {operation} operation.");
        }
    }
}