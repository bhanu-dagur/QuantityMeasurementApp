namespace QuantityMeasurementApp.Tests;

using QuantityMeasurementApp;

[TestClass]
public sealed class QuantityMeasurementAppTest
{
    [TestMethod]
    public void TestFeetEquality_SameValue()
    {
        var feet1 = new QuantityMeasurementApplication.Feet(1.0);
        var feet2 = new QuantityMeasurementApplication.Feet(1.0);

        Assert.IsTrue(feet1.Equals(feet2));
    }
    [TestMethod]
    public void TestFeetEquality_DifferentValue()
    {
        var feet1 = new QuantityMeasurementApplication.Feet(1.0);
        var feet2 = new QuantityMeasurementApplication.Feet(2.0);

        Assert.IsFalse(feet1.Equals(feet2));
    }
    [TestMethod]
    public void TestFeetEquality_NullComparison()
    {
        var feet1 = new QuantityMeasurementApplication.Feet(1.0);

        Assert.IsFalse(feet1.Equals(null));
    }
    [TestMethod]
    public void TestFeetEquality_NonNumericInput()
    {
        var feet = new QuantityMeasurementApplication.Feet(1.0);

        Assert.IsFalse(feet.Equals("1"));
    }
    [TestMethod]
    public void TestFeetEquality_SameRefernce()
    {
        var feet = new QuantityMeasurementApplication.Feet(1.0);

        Assert.IsTrue(feet.Equals(feet));
    }

    [TestMethod]
    public void TestInchEquality_SameValue()
    {
        var inch1 = new QuantityMeasurementApplication.Inch(1.0);
        var inch2 = new QuantityMeasurementApplication.Inch(1.0);

        Assert.IsTrue(inch1.Equals(inch2));
    }
    [TestMethod]
    public void TestInchEquality_DifferentValue()
    {
        var inch1 = new QuantityMeasurementApplication.Inch(1.0);
        var inch2 = new QuantityMeasurementApplication.Inch(2.0);

        Assert.IsFalse(inch1.Equals(inch2));
    }
    [TestMethod]
    public void TestInchEquality_NullComparison()
    {
        var inch1 = new QuantityMeasurementApplication.Inch(1.0);

        Assert.IsFalse(inch1.Equals(null));
    }
    [TestMethod]
    public void TestInchEquality_NonNumericInput()
    {
        var inch1 = new QuantityMeasurementApplication.Inch(1.0);

        Assert.IsFalse(inch1.Equals("1"));
    }
    [TestMethod]
    public void TestInchEquality_SameRefernce()
    {
        var inch1 = new QuantityMeasurementApplication.Inch(1.0);

        Assert.IsTrue(inch1.Equals(inch1));
    }
        [TestMethod]
    public void TestEquality_FeetToFeet_SameValue()
    {
        var feet1 = new QuantityLength(1.0, LengthUnit.Feet);
        var feet2 = new QuantityLength(1.0, LengthUnit.Feet);
        Assert.IsTrue(feet1.Equals(feet2));
    }


    [TestMethod]
    public void TestEquality_InchToInch_SameValue()
    {
        var inch1 = new QuantityLength(1.0, LengthUnit.Inch);
        var inch2 = new QuantityLength(1.0, LengthUnit.Inch);
        Assert.IsTrue(inch1.Equals(inch2));
    }

    [TestMethod]
    public void TestEquality_FeetToInch_EquivalentValue()
    {
        var feet = new QuantityLength(1.0, LengthUnit.Feet);
        var inch = new QuantityLength(12.0, LengthUnit.Inch);
        Assert.IsTrue(feet.Equals(inch));
    }

 
    [TestMethod]
    public void TestEquality_InchToFeet_EquivalentValue()
    {
        var inch = new QuantityLength(12.0, LengthUnit.Inch);
        var feet = new QuantityLength(1.0, LengthUnit.Feet);
        Assert.IsTrue(inch.Equals(feet));
    }

    [TestMethod]
    public void TestEquality_FeetToFeet_DifferentValue()
    {
        var feet1 = new QuantityLength(1.0, LengthUnit.Feet);
        var feet2 = new QuantityLength(2.0, LengthUnit.Feet);
        Assert.IsFalse(feet1.Equals(feet2));
    }

   
    [TestMethod]
    public void TestEquality_InchToInch_DifferentValue()
    {
        var inch1 = new QuantityLength(1.0, LengthUnit.Inch);
        var inch2 = new QuantityLength(2.0, LengthUnit.Inch);
        Assert.IsFalse(inch1.Equals(inch2));
    }


    [TestMethod]
    public void TestEquality_SameReference()
    {
        var feet = new QuantityLength(1.0, LengthUnit.Feet);
        Assert.IsTrue(feet.Equals(feet));
    }


    [TestMethod]
    public void TestEquality_NullComparison()
    {
        var feet = new QuantityLength(1.0, LengthUnit.Feet);
        Assert.IsFalse(feet.Equals(null));
    }

    [TestMethod]
    public void TestEquality_InvalidType()
    {
        var feet = new QuantityLength(1.0, LengthUnit.Feet);
        string notAQuantity = "1.0 feet";
        Assert.IsFalse(feet.Equals(notAQuantity));
    }
}
