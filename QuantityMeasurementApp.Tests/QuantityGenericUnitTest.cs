using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.models;

namespace QuantityMeasurementApp.Tests
{
    [TestClass]
    public class QuantityGenericUnitTest
    {
        // IMeasurable Interface Tests

        [TestMethod]
        public void TestIMeasurable_LengthConvertToBase()
        {
            double result = LengthUnit.INCH.ConvertToBaseUnit(12);

            Assert.AreEqual(1.0, result);
        }

        [TestMethod]
        public void TestIMeasurable_WeightConvertToBase()
        {
            double result = WeightUnit.GRAM.ConvertToBaseUnit(1000);

            Assert.AreEqual(1.0, result);
        }

        // Equality Tests

        [TestMethod]
        public void TestEquality_SameLengthUnit()
        {
            var q1 = new Quantity<LengthUnit>(5, LengthUnit.FEET);
            var q2 = new Quantity<LengthUnit>(5, LengthUnit.FEET);

            Assert.IsTrue(q1.Equals(q2));
        }

        [TestMethod]
        public void TestEquality_DifferentLengthUnit()
        {
            var q1 = new Quantity<LengthUnit>(1, LengthUnit.FEET);
            var q2 = new Quantity<LengthUnit>(12, LengthUnit.INCH);

            Assert.IsTrue(q1.Equals(q2));
        }

        [TestMethod]
        public void TestEquality_SameWeightUnit()
        {
            var w1 = new Quantity<WeightUnit>(2, WeightUnit.KILOGRAM);
            var w2 = new Quantity<WeightUnit>(2, WeightUnit.KILOGRAM);

            Assert.IsTrue(w1.Equals(w2));
        }

        [TestMethod]
        public void TestEquality_DifferentWeightUnit()
        {
            var w1 = new Quantity<WeightUnit>(1, WeightUnit.KILOGRAM);
            var w2 = new Quantity<WeightUnit>(1000, WeightUnit.GRAM);

            Assert.IsTrue(w1.Equals(w2));
        }

        [TestMethod]
        public void TestEquality_LengthDifferentValue()
        {
            var q1 = new Quantity<LengthUnit>(1, LengthUnit.FEET);
            var q2 = new Quantity<LengthUnit>(10, LengthUnit.INCH);

            Assert.IsFalse(q1.Equals(q2));
        }

        [TestMethod]
        public void TestEquality_WeightDifferentValue()
        {
            var w1 = new Quantity<WeightUnit>(1, WeightUnit.KILOGRAM);
            var w2 = new Quantity<WeightUnit>(900, WeightUnit.GRAM);

            Assert.IsFalse(w1.Equals(w2));
        }

     
        // Conversion Tests

        [TestMethod]
        public void TestConversion_FeetToInch()
        {
            var q = new Quantity<LengthUnit>(1, LengthUnit.FEET);

            var result = q.ConvertTo(LengthUnit.INCH);

            Assert.AreEqual(12, result.Value);
        }

        [TestMethod]
        public void TestConversion_InchToFeet()
        {
            var q = new Quantity<LengthUnit>(12, LengthUnit.INCH);

            var result = q.ConvertTo(LengthUnit.FEET);

            Assert.AreEqual(1, result.Value);
        }

        [TestMethod]
        public void TestConversion_YardToFeet()
        {
            var q = new Quantity<LengthUnit>(1, LengthUnit.YARD);

            var result = q.ConvertTo(LengthUnit.FEET);

            Assert.AreEqual(3, result.Value);
        }

        [TestMethod]
        public void TestConversion_KgToGram()
        {
            var q = new Quantity<WeightUnit>(1, WeightUnit.KILOGRAM);

            var result = q.ConvertTo(WeightUnit.GRAM);

            Assert.AreEqual(1000, result.Value);
        }

        [TestMethod]
        public void TestConversion_GramToKg()
        {
            var q = new Quantity<WeightUnit>(1000, WeightUnit.GRAM);

            var result = q.ConvertTo(WeightUnit.KILOGRAM);

            Assert.AreEqual(1, result.Value);
        }

       
        // Addition Tests

        [TestMethod]
        public void TestAddition_LengthSameUnit()
        {
            var q1 = new Quantity<LengthUnit>(2, LengthUnit.FEET);
            var q2 = new Quantity<LengthUnit>(3, LengthUnit.FEET);

            var result = q1.Add(q2);

            Assert.AreEqual(5, result.Value);
        }

        [TestMethod]
        public void TestAddition_LengthDifferentUnit()
        {
            var q1 = new Quantity<LengthUnit>(1, LengthUnit.FEET);
            var q2 = new Quantity<LengthUnit>(12, LengthUnit.INCH);

            var result = q1.Add(q2, LengthUnit.FEET);

            Assert.AreEqual(2, result.Value);
        }

        [TestMethod]
        public void TestAddition_WeightSameUnit()
        {
            var w1 = new Quantity<WeightUnit>(1, WeightUnit.KILOGRAM);
            var w2 = new Quantity<WeightUnit>(1, WeightUnit.KILOGRAM);

            var result = w1.Add(w2);

            Assert.AreEqual(2, result.Value);
        }

        [TestMethod]
        public void TestAddition_WeightDifferentUnit()
        {
            var w1 = new Quantity<WeightUnit>(1, WeightUnit.KILOGRAM);
            var w2 = new Quantity<WeightUnit>(1000, WeightUnit.GRAM);

            var result = w1.Add(w2, WeightUnit.KILOGRAM);

            Assert.AreEqual(2, result.Value);
        }

        // HashCode Tests

        [TestMethod]
        public void TestHashCode_SameValues()
        {
            var q1 = new Quantity<LengthUnit>(1, LengthUnit.FEET);
            var q2 = new Quantity<LengthUnit>(12, LengthUnit.INCH);

            Assert.AreEqual(q1.GetHashCode(), q2.GetHashCode());
        }

        // ToString Tests

        [TestMethod]
        public void TestToString_Length()
        {
            var q = new Quantity<LengthUnit>(1, LengthUnit.FEET);

            Assert.AreEqual("Quantity(1, FEET)", q.ToString());
        }

        [TestMethod]
        public void TestToString_Weight()
        {
            var q = new Quantity<WeightUnit>(1, WeightUnit.KILOGRAM);

            Assert.AreEqual("Quantity(1, KILOGRAM)", q.ToString());
        }

    }
}