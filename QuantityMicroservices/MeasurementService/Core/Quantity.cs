using MeasurementService.Units;
using MeasurementService.Models;

namespace MeasurementService.Core
{
    // ============================
    // Quantity - Core Math Class
    // Ye class actual conversion/arithmetic karta hai
    // ============================
    public class Quantity
    {
        public double Value { get; }
        public Enum Unit { get; }

        public Quantity(double value, Enum unit)
        {
            Value = value;
            Unit = unit;
        }

        // ============================
        // Convert value to BASE unit
        // ============================
        private double ToBase()
        {
            return Unit switch
            {
                LengthUnit lu      => lu.ToBase(Value),
                WeightUnit wu      => wu.ToBase(Value),
                VolumeUnit vu      => vu.ToBase(Value),
                TemperatureUnit tu => tu.ToBase(Value),
                _ => throw new ArgumentException("Unsupported unit type")
            };
        }

        // ============================
        // Convert FROM base to target unit
        // ============================
        private static double FromBase(double baseValue, Enum targetUnit)
        {
            return targetUnit switch
            {
                LengthUnit lu      => lu.FromBase(baseValue),
                WeightUnit wu      => wu.FromBase(baseValue),
                VolumeUnit vu      => vu.FromBase(baseValue),
                TemperatureUnit tu => tu.FromBase(baseValue),
                _ => throw new ArgumentException("Unsupported target unit")
            };
        }

        // ============================
        // CONVERT - ek unit se doosre me
        // ============================
        public ResultDTO ConvertTo(Enum targetUnit)
        {
            double baseVal = ToBase();
            double result = FromBase(baseVal, targetUnit);

            return new ResultDTO
            {
                ResultValue = Math.Round(result, 4),
                ResultUnit = targetUnit.ToString()!,
                Operation = "Conversion"
            };
        }

        // ============================
        // ADD - do quantities add karo
        // ============================
        public ResultDTO Add(Quantity other, Enum targetUnit)
        {
            double base1 = ToBase();
            double base2 = other.ToBase();
            double result = FromBase(base1 + base2, targetUnit);

            return new ResultDTO
            {
                ResultValue = Math.Round(result, 4),
                ResultUnit = targetUnit.ToString()!,
                Operation = "Addition"
            };
        }

        // ============================
        // SUBTRACT
        // ============================
        public ResultDTO Subtract(Quantity other, Enum targetUnit)
        {
            double base1 = ToBase();
            double base2 = other.ToBase();
            double result = FromBase(base1 - base2, targetUnit);

            return new ResultDTO
            {
                ResultValue = Math.Round(result, 4),
                ResultUnit = targetUnit.ToString()!,
                Operation = "Subtraction"
            };
        }

        // ============================
        // DIVIDE
        // ============================
        public ResultDTO Divide(Quantity other, Enum targetUnit)
        {
            double base2 = other.ToBase();
            if (base2 == 0) throw new DivideByZeroException("Cannot divide by zero!");

            double base1 = ToBase();
            double result = FromBase(base1 / base2, targetUnit);

            return new ResultDTO
            {
                ResultValue = Math.Round(result, 4),
                ResultUnit = targetUnit.ToString()!,
                Operation = "Division"
            };
        }

        // ============================
        // EQUALITY CHECK
        // ============================
        public bool IsEqualTo(Quantity other)
        {
            return Math.Abs(ToBase() - other.ToBase()) < 0.0001;
        }
    }
}
