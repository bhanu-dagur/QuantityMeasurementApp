using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp
{
    public class QuantityMeasurementApplication
    {
        // Generic Equality Demonstration
        public static void DemonstrateEquality<U>(Quantity<U> q1, Quantity<U> q2) where U : Enum
        {
            Console.WriteLine("Checking Equality:");
            Console.WriteLine($"{q1} == {q2} -> {q1.Equals(q2)}");
            Console.WriteLine();
        }

        // Generic Conversion Demonstration
        public static void DemonstrateConversion<U>(Quantity<U> quantity, U targetUnit) where U : Enum
        {
            var result = quantity.ConvertTo(targetUnit);

            Console.WriteLine("Conversion:");
            Console.WriteLine($"{quantity} -> {result}");
            Console.WriteLine();
        }

        // Generic Addition Demonstration
        public static void DemonstrateAddition<U>(Quantity<U> q1, Quantity<U> q2, U targetUnit) where U : Enum
        {
            var result = q1.Add(q2, targetUnit);

            Console.WriteLine("Addition:");
            Console.WriteLine($"{q1} + {q2} = {result}");
            Console.WriteLine();
        }

        // UC12 Subtraction Demonstration
        public static void DemonstrateSubtraction<U>(Quantity<U> q1, Quantity<U> q2, U targetUnit) where U : Enum
        {
            var result = q1.Subtract(q2, targetUnit);

            Console.WriteLine("Subtraction:");
            Console.WriteLine($"{q1} - {q2} = {result}");
            Console.WriteLine();
        }

        // UC12 Division Demonstration
        public static void DemonstrateDivision<U>(Quantity<U> q1, Quantity<U> q2) where U : Enum
        {
            double result = q1.Divide(q2);

            Console.WriteLine("Division:");
            Console.WriteLine($"{q1} / {q2} = {result}");
            Console.WriteLine();
        }

        // Length Operations
        public static void DemonstrateLengthOperations()
        {
            Console.WriteLine("Length Operations:");

            var length1 = new Quantity<LengthUnit>(10.0, LengthUnit.FEET);
            var length2 = new Quantity<LengthUnit>(6.0, LengthUnit.INCH);

            DemonstrateEquality(length1, length2);
            DemonstrateConversion(length1, LengthUnit.INCH);
            DemonstrateAddition(length1, length2, LengthUnit.FEET);

            // UC12
            DemonstrateSubtraction(length1, length2, LengthUnit.FEET);
            DemonstrateDivision(length1, new Quantity<LengthUnit>(2.0, LengthUnit.FEET));
        }

        // Weight Operations
        public static void DemonstrateWeightOperations()
        {
            Console.WriteLine("Weight Operations:");

            var weight1 = new Quantity<WeightUnit>(10.0, WeightUnit.KILOGRAM);
            var weight2 = new Quantity<WeightUnit>(5000.0, WeightUnit.GRAM);

            DemonstrateEquality(weight1, weight2);
            DemonstrateConversion(weight1, WeightUnit.GRAM);
            DemonstrateAddition(weight1, weight2, WeightUnit.KILOGRAM);

            // UC12
            DemonstrateSubtraction(weight1, weight2, WeightUnit.KILOGRAM);
            DemonstrateDivision(weight1, new Quantity<WeightUnit>(5.0, WeightUnit.KILOGRAM));
        }

        // Volume Operations
        public static void DemonstrateVolumeOperations()
        {
            Console.WriteLine("Volume Operations:");

            var volume1 = new Quantity<VolumeUnit>(5.0, VolumeUnit.LITRE);
            var volume2 = new Quantity<VolumeUnit>(500.0, VolumeUnit.MILLILITRE);
            var volume3 = new Quantity<VolumeUnit>(3.78541, VolumeUnit.GALLON);

            DemonstrateEquality(volume1, volume2);
            DemonstrateConversion(volume1, VolumeUnit.MILLILITRE);
            DemonstrateAddition(volume1, volume2, VolumeUnit.LITRE);
            DemonstrateAddition(volume1, volume3, VolumeUnit.LITRE);

            // UC12
            DemonstrateSubtraction(volume1, volume2, VolumeUnit.LITRE);
            DemonstrateDivision(volume1, new Quantity<VolumeUnit>(10.0, VolumeUnit.LITRE));
        }
        public static void DemonstrateTemperatureOperations()
        {
            Console.WriteLine("Temperature Operations:");

            var t1 = new Quantity<TemperatureUnit>(0.0, TemperatureUnit.CELSIUS);
            var t2 = new Quantity<TemperatureUnit>(32.0, TemperatureUnit.FAHRENHEIT);

            DemonstrateEquality(t1, t2);

            DemonstrateConversion(t1, TemperatureUnit.FAHRENHEIT);

            try
            {
                t1.Add(t2, TemperatureUnit.CELSIUS);
            }
            catch (Exception e)
            {
                Console.WriteLine("Addition Error: " + e.Message);
            }

            Console.WriteLine();
        }
    }
}