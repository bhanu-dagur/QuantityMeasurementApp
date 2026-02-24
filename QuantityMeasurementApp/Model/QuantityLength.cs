public class QuantityLength
{
    private readonly double _value;
    private readonly LengthUnit _unit;

    public QuantityLength(double value,LengthUnit unit)
    {
        _value=value;
        _unit=unit;
    }
    public double Value=>_value;
    public LengthUnit Unit=>_unit;

    private double ConvertToFeet()
    {
        return _unit switch
        {
            LengthUnit.Feet => _value,
            LengthUnit.Inch => _value/12.0,
            _=> throw new InvalidOperationException("Invalid unit")
        };
    }
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj))
            return true;

        if (obj == null || obj.GetType() != this.GetType())
            return false;

        var other = (QuantityLength)obj;
        double feet1=this.ConvertToFeet();
        double feet2=other.ConvertToFeet();
        return Math.Abs(feet1 - feet2) < 0.0001;
    }

    public override int GetHashCode()
    {
        return ConvertToFeet().GetHashCode();
    }

    public override string ToString()
    {
        return $"QunatityLength: {_value} {_unit}";
    }


}