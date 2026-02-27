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

    // 🔥 Base unit = Inches
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
}