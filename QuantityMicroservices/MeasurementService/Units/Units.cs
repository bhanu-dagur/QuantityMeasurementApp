namespace MeasurementService.Units;

public enum LengthUnit { FEET, INCH, YARD, CENTIMETER }

public static class LengthUnitExtensions
{
    public static double GetFactor(this LengthUnit unit) => unit switch
    {
        LengthUnit.FEET => 1.0,
        LengthUnit.INCH => 1.0 / 12.0,
        LengthUnit.YARD => 3.0,
        LengthUnit.CENTIMETER => 1.0 / 30.48,
        _ => throw new ArgumentException($"Unknown length unit: {unit}")
    };

    public static double ToBase(this LengthUnit unit, double value) => value * unit.GetFactor();
    public static double FromBase(this LengthUnit unit, double value) => value / unit.GetFactor();
}

public enum WeightUnit { KILOGRAM, GRAM, POUND, OUNCE }

public static class WeightUnitExtensions
{
    public static double GetFactor(this WeightUnit unit) => unit switch
    {
        WeightUnit.KILOGRAM => 1.0,
        WeightUnit.GRAM => 0.001,
        WeightUnit.POUND => 0.453592,
        WeightUnit.OUNCE => 0.0283495,
        _ => throw new ArgumentException($"Unknown weight unit: {unit}")
    };

    public static double ToBase(this WeightUnit unit, double value) => value * unit.GetFactor();
    public static double FromBase(this WeightUnit unit, double value) => value / unit.GetFactor();
}

public enum VolumeUnit { LITER, MILLILITER, GALLON, CUBIC_FEET }

public static class VolumeUnitExtensions
{
    public static double GetFactor(this VolumeUnit unit) => unit switch
    {
        VolumeUnit.LITER => 1.0,
        VolumeUnit.MILLILITER => 0.001,
        VolumeUnit.GALLON => 3.78541,
        VolumeUnit.CUBIC_FEET => 28.3168,
        _ => throw new ArgumentException($"Unknown volume unit: {unit}")
    };

    public static double ToBase(this VolumeUnit unit, double value) => value * unit.GetFactor();
    public static double FromBase(this VolumeUnit unit, double value) => value / unit.GetFactor();
}

public enum TemperatureUnit { CELSIUS, FAHRENHEIT, KELVIN }

public static class TemperatureUnitExtensions
{

    public static double ToBase(this TemperatureUnit unit, double value) => unit switch
    {
        TemperatureUnit.CELSIUS => value,
        TemperatureUnit.FAHRENHEIT => (value - 32) * 5.0 / 9.0,
        TemperatureUnit.KELVIN => value - 273.15,
        _ => throw new ArgumentException($"Unknown temp unit: {unit}")
    };

    public static double FromBase(this TemperatureUnit unit, double celsius) => unit switch
    {
        TemperatureUnit.CELSIUS => celsius,
        TemperatureUnit.FAHRENHEIT => (celsius * 9.0 / 5.0) + 32,
        TemperatureUnit.KELVIN => celsius + 273.15,
        _ => throw new ArgumentException($"Unknown temp unit: {unit}")
    };
}

