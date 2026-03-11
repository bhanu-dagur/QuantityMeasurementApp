using QuantityMeasurementApp.models;

namespace QuantityMeasurementApp
{
    public class QuantityMeasurementApplication
    {
        // Generic Equality Demonstration
        public static void DemonstrateEquality<U>(Quantity<U> q1, Quantity<U> q2)
        {
            Console.WriteLine("Checking Equality:");
            Console.WriteLine($"{q1} == {q2} -> {q1.Equals(q2)}");
            Console.WriteLine();
        }

        // Generic Conversion Demonstration
        public static void DemonstrateConversion<U>(Quantity<U> quantity, U targetUnit)
        {
            var result = quantity.ConvertTo(targetUnit);

            Console.WriteLine("Conversion:");
            Console.WriteLine($"{quantity} -> {result}");
            Console.WriteLine();
        }

        // Generic Addition Demonstration
        public static void DemonstrateAddition<U>(Quantity<U> q1, Quantity<U> q2, U targetUnit)
        {
            var result = q1.Add(q2, targetUnit);

            Console.WriteLine("Addition:");
            Console.WriteLine($"{q1} + {q2} = {result}");
            Console.WriteLine();
        }

        // Main demonstration method for Length
        public static void DemonstrateLengthOperations()
        {
            Console.WriteLine("Length Operations:");

            var length1 = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);
            var length2 = new Quantity<LengthUnit>(12.0, LengthUnit.INCH);

            DemonstrateEquality(length1, length2);
            DemonstrateConversion(length1, LengthUnit.INCH);
            DemonstrateAddition(length1, length2, LengthUnit.FEET);
        }

        // Main demonstration method for Weight
        public static void DemonstrateWeightOperations()
        {
            Console.WriteLine("Weight Operations:");

            var weight1 = new Quantity<WeightUnit>(1.0, WeightUnit.KILOGRAM);
            var weight2 = new Quantity<WeightUnit>(1000.0, WeightUnit.GRAM);

            DemonstrateEquality(weight1, weight2);
            DemonstrateConversion(weight1, WeightUnit.GRAM);
            DemonstrateAddition(weight1, weight2, WeightUnit.KILOGRAM);
        }
    }
}