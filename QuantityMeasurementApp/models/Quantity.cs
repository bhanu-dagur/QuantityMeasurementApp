namespace QuantityMeasurementApp.models
{
    public class Quantity<U>
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

            else
                throw new ArgumentException("Unsupported unit");

            return new Quantity<U>(Math.Round(converted, 2), targetUnit);
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

            else
                throw new ArgumentException("Unsupported unit");

            return new Quantity<U>(Math.Round(result, 2), targetUnit);
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
            if (unit is LengthUnit lengthUnit)
                return $"Quantity({value}, {lengthUnit.GetUnitName()})";

            if (unit is WeightUnit weightUnit)
                return $"Quantity({value}, {weightUnit.GetUnitName()})";

            return $"Quantity({value})";
        }
    }
}