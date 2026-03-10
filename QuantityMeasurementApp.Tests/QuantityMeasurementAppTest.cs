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

    //UC 5
    [TestMethod]
    public void TestConversion_FeetToInches()
    {
        double result = QuantityLength.Convert(1.0, LengthUnit.Feet, LengthUnit.Inch);
        Assert.AreEqual(12.0, result, 0.0001);
    }

    [TestMethod]
    public void TestConversion_InchesToFeet()
    {
        double result = QuantityLength.Convert(24.0, LengthUnit.Inch, LengthUnit.Feet);
        Assert.AreEqual(2.0, result, 0.0001);
    }

    [TestMethod]
    public void TestConversion_YardsToInches()
    {
        double result = QuantityLength.Convert(1.0, LengthUnit.Yards, LengthUnit.Inch);
        Assert.AreEqual(36.0, result, 0.0001);
    }

    [TestMethod]
    public void TestConversion_InchesToYards()
    {
        double result = QuantityLength.Convert(72.0, LengthUnit.Inch, LengthUnit.Yards);
        Assert.AreEqual(2.0, result, 0.0001);
    }

    [TestMethod]
    public void TestConversion_CentimetersToInches()
    {
        double result = QuantityLength.Convert(2.54, LengthUnit.Centimeters, LengthUnit.Inch);
        Assert.AreEqual(1.0, result, 0.01);
    }

    [TestMethod]
    public void TestConversion_FeetToYards()
    {
        double result = QuantityLength.Convert(6.0, LengthUnit.Feet, LengthUnit.Yards);
        Assert.AreEqual(2.0, result, 0.0001);
    }

    [TestMethod]
    public void TestConversion_ZeroValue()
    {
        double result = QuantityLength.Convert(0.0, LengthUnit.Feet, LengthUnit.Inch);
        Assert.AreEqual(0.0, result);
    }

    [TestMethod]
    public void TestConversion_NegativeValue()
    {
        double result = QuantityLength.Convert(-1.0, LengthUnit.Feet, LengthUnit.Inch);
        Assert.AreEqual(-12.0, result);
    }
    // UC6 ADDITION TEST CASES


    [TestMethod]
    public void TestAddition_SameUnit_FeetPlusFeet()
    {
        var q1 = new QuantityLength(1.0, LengthUnit.Feet);
        var q2 = new QuantityLength(2.0, LengthUnit.Feet);

        var result = QuantityLength.Add(q1, q2);

        Assert.AreEqual(3.0, result.Value, 0.0001);
        Assert.AreEqual(LengthUnit.Feet, result.Unit);
    }

    [TestMethod]
    public void TestAddition_SameUnit_InchPlusInch()
    {
        var q1 = new QuantityLength(6.0, LengthUnit.Inch);
        var q2 = new QuantityLength(6.0, LengthUnit.Inch);

        var result = QuantityLength.Add(q1, q2);

        Assert.AreEqual(12.0, result.Value, 0.0001);
        Assert.AreEqual(LengthUnit.Inch, result.Unit);
    }

    [TestMethod]
    public void TestAddition_CrossUnit_FeetPlusInches()
    {
        var q1 = new QuantityLength(1.0, LengthUnit.Feet);
        var q2 = new QuantityLength(12.0, LengthUnit.Inch);

        var result = QuantityLength.Add(q1, q2);

        Assert.AreEqual(2.0, result.Value, 0.0001);
        Assert.AreEqual(LengthUnit.Feet, result.Unit);
    }

    [TestMethod]
    public void TestAddition_CrossUnit_InchPlusFeet()
    {
        var q1 = new QuantityLength(12.0, LengthUnit.Inch);
        var q2 = new QuantityLength(1.0, LengthUnit.Feet);

        var result = QuantityLength.Add(q1, q2);

        Assert.AreEqual(24.0, result.Value, 0.0001);
        Assert.AreEqual(LengthUnit.Inch, result.Unit);
    }

    [TestMethod]
    public void TestAddition_CrossUnit_YardPlusFeet()
    {
        var q1 = new QuantityLength(1.0, LengthUnit.Yards);
        var q2 = new QuantityLength(3.0, LengthUnit.Feet);

        var result = QuantityLength.Add(q1, q2);

        Assert.AreEqual(2.0, result.Value, 0.0001);
        Assert.AreEqual(LengthUnit.Yards, result.Unit);
    }

    [TestMethod]
    public void TestAddition_CrossUnit_CentimeterPlusInch()
    {
        var q1 = new QuantityLength(2.54, LengthUnit.Centimeters);
        var q2 = new QuantityLength(1.0, LengthUnit.Inch);

        var result = QuantityLength.Add(q1, q2);

        Assert.AreEqual(5.08, result.Value, 0.1);
        Assert.AreEqual(LengthUnit.Centimeters, result.Unit);
    }

    [TestMethod]
    public void TestAddition_Commutativity()
    {
        var q1 = new QuantityLength(1.0, LengthUnit.Feet);
        var q2 = new QuantityLength(12.0, LengthUnit.Inch);

        var result1 = QuantityLength.Add(q1, q2);
        var result2 = QuantityLength.Add(q2, q1);

        double r1 = QuantityLength.Convert(result1.Value, result1.Unit, LengthUnit.Inch);
        double r2 = QuantityLength.Convert(result2.Value, result2.Unit, LengthUnit.Inch);

        Assert.AreEqual(r1, r2, 0.0001);
    }

    [TestMethod]
    public void TestAddition_WithZero()
    {
        var q1 = new QuantityLength(5.0, LengthUnit.Feet);
        var q2 = new QuantityLength(0.0, LengthUnit.Inch);

        var result = QuantityLength.Add(q1, q2);

        Assert.AreEqual(5.0, result.Value, 0.0001);
    }

    [TestMethod]
    public void TestAddition_NegativeValues()
    {
        var q1 = new QuantityLength(5.0, LengthUnit.Feet);
        var q2 = new QuantityLength(-2.0, LengthUnit.Feet);

        var result = QuantityLength.Add(q1, q2);

        Assert.AreEqual(3.0, result.Value, 0.0001);
    }

    [TestMethod]

    public void TestAddition_NullSecondOperand()
    {
        var q1 = new QuantityLength(1.0, LengthUnit.Feet);
        Assert.Throws<ArgumentException>(() => QuantityLength.Add(q1, null));
    }

    [TestMethod]
    public void TestAddition_LargeValues()
    {
        var q1 = new QuantityLength(1e6, LengthUnit.Feet);
        var q2 = new QuantityLength(1e6, LengthUnit.Feet);

        var result = QuantityLength.Add(q1, q2);

        Assert.AreEqual(2e6, result.Value, 0.0001);
    }

    [TestMethod]
    public void TestAddition_SmallValues()
    {
        var q1 = new QuantityLength(0.001, LengthUnit.Feet);
        var q2 = new QuantityLength(0.002, LengthUnit.Feet);

        var result = QuantityLength.Add(q1, q2);

        Assert.AreEqual(0.003, result.Value, 0.0001);
    }

    // UC7 ADDITION WITH TARGET UNIT

    [TestMethod]
    public void TestAddition_ExplicitTargetUnit_Feet()
    {
        var q1 = new QuantityLength(1.0, LengthUnit.Feet);
        var q2 = new QuantityLength(12.0, LengthUnit.Inch);

        var result = QuantityLength.Add(q1, q2, LengthUnit.Feet);

        Assert.AreEqual(2.0, result.Value, 0.0001);
    }

    [TestMethod]
    public void TestAddition_ExplicitTargetUnit_Inches()
    {
        var q1 = new QuantityLength(1.0, LengthUnit.Feet);
        var q2 = new QuantityLength(12.0, LengthUnit.Inch);

        var result = QuantityLength.Add(q1, q2, LengthUnit.Inch);

        Assert.AreEqual(24.0, result.Value, 0.0001);
    }

    [TestMethod]
    public void TestAddition_ExplicitTargetUnit_Yards()
    {
        var q1 = new QuantityLength(1.0, LengthUnit.Feet);
        var q2 = new QuantityLength(12.0, LengthUnit.Inch);

        var result = QuantityLength.Add(q1, q2, LengthUnit.Yards);

        Assert.AreEqual(0.667, result.Value, 0.01);
    }

    [TestMethod]
    public void TestAddition_ExplicitTargetUnit_Centimeters()
    {
        var q1 = new QuantityLength(1.0, LengthUnit.Inch);
        var q2 = new QuantityLength(1.0, LengthUnit.Inch);

        var result = QuantityLength.Add(q1, q2, LengthUnit.Centimeters);

        Assert.AreEqual(5.08, result.Value, 0.01);
    }

    [TestMethod]
    public void TestAddition_ExplicitTargetUnit_SameAsFirstOperand()
    {
        var q1 = new QuantityLength(2.0, LengthUnit.Yards);
        var q2 = new QuantityLength(3.0, LengthUnit.Feet);

        var result = QuantityLength.Add(q1, q2, LengthUnit.Yards);

        Assert.AreEqual(3.0, result.Value, 0.0001);
    }

    [TestMethod]
    public void TestAddition_ExplicitTargetUnit_SameAsSecondOperand()
    {
        var q1 = new QuantityLength(2.0, LengthUnit.Yards);
        var q2 = new QuantityLength(3.0, LengthUnit.Feet);

        var result = QuantityLength.Add(q1, q2, LengthUnit.Feet);

        Assert.AreEqual(9.0, result.Value, 0.0001);
    }

    [TestMethod]
    public void TestAddition_ExplicitTargetUnit_Commutativity()
    {
        var q1 = new QuantityLength(1.0, LengthUnit.Feet);
        var q2 = new QuantityLength(12.0, LengthUnit.Inch);

        var result1 = QuantityLength.Add(q1, q2, LengthUnit.Yards);
        var result2 = QuantityLength.Add(q2, q1, LengthUnit.Yards);

        Assert.AreEqual(result1.Value, result2.Value, 0.0001);
    }

    [TestMethod]
    public void TestAddition_ExplicitTargetUnit_WithZero()
    {
        var q1 = new QuantityLength(5.0, LengthUnit.Feet);
        var q2 = new QuantityLength(0.0, LengthUnit.Inch);

        var result = QuantityLength.Add(q1, q2, LengthUnit.Yards);

        Assert.AreEqual(1.667, result.Value, 0.01);
    }

    [TestMethod]
    public void TestAddition_ExplicitTargetUnit_NegativeValues()
    {
        var q1 = new QuantityLength(5.0, LengthUnit.Feet);
        var q2 = new QuantityLength(-2.0, LengthUnit.Feet);

        var result = QuantityLength.Add(q1, q2, LengthUnit.Inch);

        Assert.AreEqual(36.0, result.Value, 0.0001);
    }

    

}
