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
        private double ConvertFromBase(double baseValue, U targetUnit)
        {
            if (targetUnit is LengthUnit l)
                return l.ConvertFromBaseUnit(baseValue);

            if (targetUnit is WeightUnit w)
                return w.ConvertFromBaseUnit(baseValue);

            if (targetUnit is VolumeUnit v)
                return v.ConvertFromBaseUnit(baseValue);

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
            ValidateArithmeticOperands(other, targetUnit, true);

            double baseResult = PerformBaseArithmetic(other, ArithmeticOperation.ADD);

            double converted = ConvertFromBase(baseResult, targetUnit);

            return new Quantity<U>(Math.Round(converted, 2), targetUnit);
        }
        public Quantity<U> Subtract(Quantity<U> other)
        {
            return Subtract(other, this.unit);
        }

        public Quantity<U> Subtract(Quantity<U> other, U targetUnit)
        {
            ValidateArithmeticOperands(other, targetUnit, true);

            double baseResult = PerformBaseArithmetic(other, ArithmeticOperation.SUBTRACT);

            double converted = ConvertFromBase(baseResult, targetUnit);

            return new Quantity<U>(Math.Round(converted, 2), targetUnit);
        }
        public double Divide(Quantity<U> other)
        {
            ValidateArithmeticOperands(other, default, false);

            return PerformBaseArithmetic(other, ArithmeticOperation.DIVIDE);
        }


        private void ValidateArithmeticOperands(Quantity<U> other, U targetUnit, bool targetUnitRequired)
        {
            if (other == null)
                throw new ArgumentException("Other quantity cannot be null");

            if (this.unit.GetType() != other.unit.GetType())
                throw new ArgumentException("Different measurement categories");

            if (!double.IsFinite(this.value) || !double.IsFinite(other.value))
                throw new ArgumentException("Invalid numeric value");

            if (targetUnitRequired && targetUnit == null)
                throw new ArgumentException("Target unit cannot be null");
        }
        private double PerformBaseArithmetic(Quantity<U> other, ArithmeticOperation operation)
        {
            double base1 = ConvertToBase();
            double base2 = other.ConvertToBase();

            return operation.Compute(base1, base2);
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