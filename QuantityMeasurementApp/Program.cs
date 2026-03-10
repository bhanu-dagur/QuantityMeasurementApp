class Program
{
    public static void Main()
    {
        QuantityMeasurementApplication.DemonstrateLengthEquality();
        var q1 = new QuantityLength(1.0, LengthUnit.Feet);
        var q2 = new QuantityLength(12.0, LengthUnit.Inch);

        var result = QuantityLength.Add(q1, q2);

        Console.WriteLine(result);
    }
}