namespace QuantityMeasurementApp.Models
{
    public enum LengthUnit : int
    {
        FEET,
        INCH,
        YARD,
        CENTIMETER
    }

    public static class LengthUnitExtension
    {
        public static double GetConversionFactor(this LengthUnit unit)
        {
            return unit switch
            {
                LengthUnit.FEET => 1.0,
                LengthUnit.INCH => 1.0 / 12.0,
                LengthUnit.YARD => 3.0,
                LengthUnit.CENTIMETER => 1.0 / 30.48,
                _ => throw new ArgumentException("Invalid Length Unit")
            };
        }

        public static double ConvertToBaseUnit(this LengthUnit unit, double value)
        {
            return value * unit.GetConversionFactor();
        }

        public static double ConvertFromBaseUnit(this LengthUnit unit, double baseValue)
        {
            return baseValue / unit.GetConversionFactor();
        }

        public static string GetUnitName(this LengthUnit unit)
        {
            return unit.ToString();
        }
        public static bool SupportsArithmetic(this LengthUnit unit)
        {
            return true;
        }

        public static void ValidateOperationSupport(this LengthUnit unit, string operation)
        {
            if(!SupportsArithmetic(unit))
                throw new UnsupportedOperationException(
                $"Temperature does not support {operation} operation.");
           
        }
    }
}