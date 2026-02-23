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
}
