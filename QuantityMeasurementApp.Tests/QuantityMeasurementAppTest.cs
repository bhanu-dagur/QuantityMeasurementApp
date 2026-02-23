namespace QuantityMeasurementApp.Tests;

using QuantityMeasurementApp;

[TestClass]
public sealed class QuantityMeasurementAppTest
{
    [TestMethod]
    public void TestEquality_SameValue()
    {
        var feet1 = new QuantityMeasurementApplication.Feet(1.0);
        var feet2 = new QuantityMeasurementApplication.Feet(1.0);

        Assert.IsTrue(feet1.Equals(feet2));
    }
    [TestMethod]
    public void TestEquality_DifferentValue()
    {
        var feet1 = new QuantityMeasurementApplication.Feet(1.0);
        var feet2 = new QuantityMeasurementApplication.Feet(2.0);

        Assert.IsFalse(feet1.Equals(feet2));
    }
    [TestMethod]
    public void TestEquality_NullComparison()
    {
        var feet1 = new QuantityMeasurementApplication.Feet(1.0);

        Assert.IsFalse(feet1.Equals(null));
    }

    [TestMethod]
    public void TestEquality_NonNumericInput()
    {
        var feet = new QuantityMeasurementApplication.Feet(1.0);

        Assert.IsFalse(feet.Equals("1"));
    }

    [TestMethod]
    public void TestEquality_SameRefernce()
    {
        var feet = new QuantityMeasurementApplication.Feet(1.0);

        Assert.IsTrue(feet.Equals(feet));
    }
}
