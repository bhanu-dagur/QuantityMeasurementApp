namespace QuantityMeasurementApp.models
{
    public class Quantity<U> where U : Enum
    {
        private readonly double value;
        private readonly U unit;

        public Quantity(double value, U unit)
        {
            if (unit == null)
                throw new ArgumentException("Unit cannot be null");

            if (double.IsNaN(value) || double.IsInfinity(value))
                throw new ArgumentException("Invalid value");

            this.value = value;
            this.unit = unit;
        }

        public double Value => value;

        public U Unit => unit;

        private double ConvertToBase()
        {
            if (unit is LengthUnit lengthUnit)
                return lengthUnit.ConvertToBaseUnit(value);

            if (unit is WeightUnit weightUnit)
                return weightUnit.ConvertToBaseUnit(value);

            if (unit is VolumeUnit volumeUnit)
                return volumeUnit.ConvertToBaseUnit(value);

            throw new ArgumentException("Unsupported unit");
        }

        public Quantity<U> ConvertTo(U targetUnit)
        {
            double baseValue = ConvertToBase();
            double converted;

            if (targetUnit is LengthUnit lengthUnit)
                converted = lengthUnit.ConvertFromBaseUnit(baseValue);

            else if (targetUnit is WeightUnit weightUnit)
                converted = weightUnit.ConvertFromBaseUnit(baseValue);

            else if (targetUnit is VolumeUnit volumeUnit)
                converted = volumeUnit.ConvertFromBaseUnit(baseValue);

            else
                throw new ArgumentException("Unsupported unit");

            return new Quantity<U>(Math.Round(converted, 5), targetUnit);
        }

        public Quantity<U> Add(Quantity<U> other)
        {
            return Add(other, this.unit);
        }

        public Quantity<U> Add(Quantity<U> other, U targetUnit)
        {
            double base1 = ConvertToBase();
            double base2 = other.ConvertToBase();

            double sumBase = base1 + base2;
            double result;

            if (targetUnit is LengthUnit lengthUnit)
                result = lengthUnit.ConvertFromBaseUnit(sumBase);

            else if (targetUnit is WeightUnit weightUnit)
                result = weightUnit.ConvertFromBaseUnit(sumBase);

            else if (targetUnit is VolumeUnit volumeUnit)
                result = volumeUnit.ConvertFromBaseUnit(sumBase);

            else
                throw new ArgumentException("Unsupported unit");

            return new Quantity<U>(Math.Round(result, 5), targetUnit);
        }
        public Quantity<U> Subtract(Quantity<U> other)
        {
            if (other == null)
                throw new ArgumentException("Other quantity cannot be null");

            return Subtract(other, this.unit);
        }
        public Quantity<U> Subtract(Quantity<U> other, U targetUnit)
        {
            if (other == null)
                throw new ArgumentException("Other quantity cannot be null");

            if (targetUnit == null)
                throw new ArgumentException("Target unit cannot be null");

            double base1 = ConvertToBase();
            double base2 = other.ConvertToBase();

            double resultBase = base1 - base2;
            double result;

            if (targetUnit is LengthUnit l)
                result = l.ConvertFromBaseUnit(resultBase);

            else if (targetUnit is WeightUnit w)
                result = w.ConvertFromBaseUnit(resultBase);

            else if (targetUnit is VolumeUnit v)
                result = v.ConvertFromBaseUnit(resultBase);

            else
                throw new ArgumentException("Unsupported unit");

            return new Quantity<U>(Math.Round(result, 2), targetUnit);
        }
        public double Divide(Quantity<U> other)
        {
            if (other == null)
                throw new ArgumentException("Other quantity cannot be null");

            double base1 = ConvertToBase();
            double base2 = other.ConvertToBase();

            if (base2 == 0)
                throw new ArithmeticException("Division by zero");

            return base1 / base2;
        }
        public override bool Equals(object obj)
        {
            if (obj == null || obj is not Quantity<U> other)
                return false;

            return ConvertToBase() == other.ConvertToBase();
        }

        public override int GetHashCode()
        {
            return ConvertToBase().GetHashCode();
        }

        public override string ToString()
        {
            if (unit is LengthUnit l)
                return $"Quantity({value}, {l.GetUnitName()})";

            if (unit is WeightUnit w)
                return $"Quantity({value}, {w.GetUnitName()})";

            if (unit is VolumeUnit v)
                return $"Quantity({value}, {v.GetUnitName()})";

            return $"Quantity({value})";
        }
    }
}