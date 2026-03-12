using System;

namespace QuantityMeasurementApp.Models
{
    public enum TemperatureUnit
    {
        CELSIUS,
        FAHRENHEIT,
        KELVIN
    }

    public static class TemperatureUnitExtensions
    {

        public static double ConvertToBaseUnit(this TemperatureUnit unit, double value)
        {
            switch (unit)
            {
                case TemperatureUnit.CELSIUS:
                    return value;

                case TemperatureUnit.FAHRENHEIT:
                    return (value - 32) * 5 / 9;

                case TemperatureUnit.KELVIN:
                    return value - 273.15;

                default:
                    throw new ArgumentException("Invalid temperature unit");
            }
        }

        public static double ConvertFromBaseUnit(this TemperatureUnit unit, double baseValue)
        {
            switch (unit)
            {
                case TemperatureUnit.CELSIUS:
                    return baseValue;

                case TemperatureUnit.FAHRENHEIT:
                    return (baseValue * 9 / 5) + 32;

                case TemperatureUnit.KELVIN:
                    return baseValue + 273.15;

                default:
                    throw new ArgumentException("Invalid temperature unit");
            }
        }

        public static string GetUnitName(this TemperatureUnit unit)
        {
            return unit.ToString();
        }

        //  Temperature arithmetic disabled
        public static bool SupportsArithmetic(this TemperatureUnit unit)
        {
            return false;
        }

        public static void ValidateOperationSupport(this TemperatureUnit unit, string operation)
        {
            throw new UnsupportedOperationException(
                $"Temperature does not support {operation} operation.");
        }
    }
}