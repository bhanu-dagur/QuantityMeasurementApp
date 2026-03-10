public class QuantityLength
{
    private readonly double _value;
    private readonly LengthUnit _unit;

    public QuantityLength(double value, LengthUnit unit)
    {
        _value = value;
        _unit = unit;
    }

    public double Value => _value;
    public LengthUnit Unit => _unit;

    //  Base unit = Inches
    private double ConvertToInches()
    {
        return _unit switch
        {
            LengthUnit.Feet => _value * 12.0,               // 1 foot = 12 inches
            LengthUnit.Inch => _value,                      // base unit
            LengthUnit.Yards => _value * 36.0,              // 1 yard = 36 inches
            LengthUnit.Centimeters => _value * 0.393701,    // 1 cm = 0.393701 inch
            _ => throw new InvalidOperationException("Invalid unit")
        };
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj))
            return true;

        if (obj == null || obj.GetType() != this.GetType())
            return false;

        var other = (QuantityLength)obj;

        double inches1 = this.ConvertToInches();
        double inches2 = other.ConvertToInches();

        return Math.Abs(inches1 - inches2) < 0.0001;
    }

    public override int GetHashCode()
    {
        return ConvertToInches().GetHashCode();
    }

    public override string ToString()
    {
        return $"QuantityLength: {_value} {_unit}";
    }
    public static double Convert(double value, LengthUnit source, LengthUnit target)
    {
        if (!double.IsFinite(value))
            throw new ArgumentException("Invalid value");

        double valueInInches = source switch
        {
            LengthUnit.Feet => value * 12.0,
            LengthUnit.Inch => value,
            LengthUnit.Yards => value * 36.0,
            LengthUnit.Centimeters => value * 0.393701,
            _ => throw new InvalidOperationException("Invalid unit")
        };

        double result = target switch
        {
            LengthUnit.Feet => valueInInches / 12.0,
            LengthUnit.Inch => valueInInches,
            LengthUnit.Yards => valueInInches / 36.0,
            LengthUnit.Centimeters => valueInInches / 0.393701,
            _ => throw new InvalidOperationException("Invalid unit")
        };

        return result;
    }
    // UC 6
    public static QuantityLength Add(QuantityLength q1, QuantityLength q2)
    {
        if (q1 == null || q2 == null)
            throw new ArgumentException("Quantity cannot be null");

        double value1 = q1.Value;
        double value2 = q2.Value;

        if (!double.IsFinite(value1) || !double.IsFinite(value2))
            throw new ArgumentException("Invalid numeric value");

        // Convert both values to inches (base unit)
        double q1Inches = q1.Unit switch
        {
            LengthUnit.Feet => value1 * 12.0,
            LengthUnit.Inch => value1,
            LengthUnit.Yards => value1 * 36.0,
            LengthUnit.Centimeters => value1 * 0.393701,
            _ => throw new InvalidOperationException("Invalid unit")
        };

        double q2Inches = q2.Unit switch
        {
            LengthUnit.Feet => value2 * 12.0,
            LengthUnit.Inch => value2,
            LengthUnit.Yards => value2 * 36.0,
            LengthUnit.Centimeters => value2 * 0.393701,
            _ => throw new InvalidOperationException("Invalid unit")
        };

        double sumInches = q1Inches + q2Inches;

        // Result should be in the unit of first operand
        double resultValue = q1.Unit switch
        {
            LengthUnit.Feet => sumInches / 12.0,
            LengthUnit.Inch => sumInches,
            LengthUnit.Yards => sumInches / 36.0,
            LengthUnit.Centimeters => sumInches / 0.393701,
            _ => throw new InvalidOperationException("Invalid unit")
        };

        return new QuantityLength(resultValue, q1.Unit);
    }
}