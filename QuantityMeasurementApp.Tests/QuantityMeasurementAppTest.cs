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

    // UC4 – YARDS TESTS


    [TestMethod]
    public void TestEquality_YardToYard_SameValue()
    {
        var q1 = new QuantityLength(1.0, LengthUnit.Yards);
        var q2 = new QuantityLength(1.0, LengthUnit.Yards);

        Assert.IsTrue(q1.Equals(q2));
    }

    [TestMethod]
    public void TestEquality_YardToYard_DifferentValue()
    {
        var q1 = new QuantityLength(1.0, LengthUnit.Yards);
        var q2 = new QuantityLength(2.0, LengthUnit.Yards);

        Assert.IsFalse(q1.Equals(q2));
    }

    [TestMethod]
    public void TestEquality_YardToFeet_EquivalentValue()
    {
        var yard = new QuantityLength(1.0, LengthUnit.Yards);
        var feet = new QuantityLength(3.0, LengthUnit.Feet);

        Assert.IsTrue(yard.Equals(feet));
    }

    [TestMethod]
    public void TestEquality_FeetToYard_EquivalentValue()
    {
        var feet = new QuantityLength(3.0, LengthUnit.Feet);
        var yard = new QuantityLength(1.0, LengthUnit.Yards);

        Assert.IsTrue(feet.Equals(yard));
    }

    [TestMethod]
    public void TestEquality_YardToInches_EquivalentValue()
    {
        var yard = new QuantityLength(1.0, LengthUnit.Yards);
        var inch = new QuantityLength(36.0, LengthUnit.Inch);

        Assert.IsTrue(yard.Equals(inch));
    }

    [TestMethod]
    public void TestEquality_InchesToYard_EquivalentValue()
    {
        var inch = new QuantityLength(36.0, LengthUnit.Inch);
        var yard = new QuantityLength(1.0, LengthUnit.Yards);

        Assert.IsTrue(inch.Equals(yard));
    }

    [TestMethod]
    public void TestEquality_YardToFeet_NonEquivalentValue()
    {
        var yard = new QuantityLength(1.0, LengthUnit.Yards);
        var feet = new QuantityLength(2.0, LengthUnit.Feet);

        Assert.IsFalse(yard.Equals(feet));
    }

    // UC4 – CENTIMETERS TESTS

    [TestMethod]
    public void TestEquality_CentimeterToCentimeter_SameValue()
    {
        var cm1 = new QuantityLength(2.0, LengthUnit.Centimeters);
        var cm2 = new QuantityLength(2.0, LengthUnit.Centimeters);

        Assert.IsTrue(cm1.Equals(cm2));
    }

    [TestMethod]
    public void TestEquality_CentimeterToInches_EquivalentValue()
    {
        var cm = new QuantityLength(1.0, LengthUnit.Centimeters);
        var inch = new QuantityLength(0.393701, LengthUnit.Inch);

        Assert.IsTrue(cm.Equals(inch));
    }

    [TestMethod]
    public void TestEquality_CentimeterToFeet_NonEquivalentValue()
    {
        var cm = new QuantityLength(1.0, LengthUnit.Centimeters);
        var feet = new QuantityLength(1.0, LengthUnit.Feet);

        Assert.IsFalse(cm.Equals(feet));
    }

    // UC4 – TRANSITIVE PROPERTY

    [TestMethod]
    public void TestEquality_MultiUnit_TransitiveProperty()
    {
        var yard = new QuantityLength(1.0, LengthUnit.Yards);
        var feet = new QuantityLength(3.0, LengthUnit.Feet);
        var inch = new QuantityLength(36.0, LengthUnit.Inch);

        Assert.IsTrue(yard.Equals(feet));
        Assert.IsTrue(feet.Equals(inch));
        Assert.IsTrue(yard.Equals(inch));
    }
}
