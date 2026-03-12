using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.models;

namespace QuantityMeasurementApp.Tests
{
    [TestClass]
    public class QuantityRefactoringTests
    {

        // ---------- ADD TESTS ----------

        [TestMethod]
        public void TestAdd_LengthDifferentUnits()
        {
            var q1 = new Quantity<LengthUnit>(1, LengthUnit.FEET);
            var q2 = new Quantity<LengthUnit>(12, LengthUnit.INCH);

            var result = q1.Add(q2);

            Assert.AreEqual(2, result.Value);
        }

        [TestMethod]
        public void TestAdd_WeightDifferentUnits()
        {
            var q1 = new Quantity<WeightUnit>(1, WeightUnit.KILOGRAM);
            var q2 = new Quantity<WeightUnit>(1000, WeightUnit.GRAM);

            var result = q1.Add(q2);

            Assert.AreEqual(2, result.Value);
        }

        [TestMethod]
        public void TestAdd_VolumeDifferentUnits()
        {
            var q1 = new Quantity<VolumeUnit>(1, VolumeUnit.LITRE);
            var q2 = new Quantity<VolumeUnit>(1000, VolumeUnit.MILLILITRE);

            var result = q1.Add(q2);

            Assert.AreEqual(2, result.Value);
        }

        // ---------- SUBTRACT TESTS ----------

        [TestMethod]
        public void TestSubtract_LengthSameUnit()
        {
            var q1 = new Quantity<LengthUnit>(10, LengthUnit.FEET);
            var q2 = new Quantity<LengthUnit>(5, LengthUnit.FEET);

            var result = q1.Subtract(q2);

            Assert.AreEqual(5, result.Value);
        }

        [TestMethod]
        public void TestSubtract_LengthDifferentUnits()
        {
            var q1 = new Quantity<LengthUnit>(10, LengthUnit.FEET);
            var q2 = new Quantity<LengthUnit>(6, LengthUnit.INCH);

            var result = q1.Subtract(q2);

            Assert.AreEqual(9.5, result.Value);
        }

        [TestMethod]
        public void TestSubtract_VolumeUnits()
        {
            var q1 = new Quantity<VolumeUnit>(5, VolumeUnit.LITRE);
            var q2 = new Quantity<VolumeUnit>(500, VolumeUnit.MILLILITRE);

            var result = q1.Subtract(q2);

            Assert.AreEqual(4.5, result.Value,0.01);
        }

        [TestMethod]
        public void TestSubtract_ResultZero()
        {
            var q1 = new Quantity<LengthUnit>(10, LengthUnit.FEET);
            var q2 = new Quantity<LengthUnit>(120, LengthUnit.INCH);

            var result = q1.Subtract(q2);

            Assert.AreEqual(0, result.Value);
        }

        [TestMethod]
        public void TestSubtract_NegativeResult()
        {
            var q1 = new Quantity<LengthUnit>(5, LengthUnit.FEET);
            var q2 = new Quantity<LengthUnit>(10, LengthUnit.FEET);

            var result = q1.Subtract(q2);

            Assert.AreEqual(-5, result.Value);
        }

        // ---------- DIVIDE TESTS ----------

        [TestMethod]
        public void TestDivide_LengthSameUnit()
        {
            var q1 = new Quantity<LengthUnit>(10, LengthUnit.FEET);
            var q2 = new Quantity<LengthUnit>(2, LengthUnit.FEET);

            var result = q1.Divide(q2);

            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void TestDivide_LengthDifferentUnits()
        {
            var q1 = new Quantity<LengthUnit>(24, LengthUnit.INCH);
            var q2 = new Quantity<LengthUnit>(2, LengthUnit.FEET);

            var result = q1.Divide(q2);

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void TestDivide_WeightUnits()
        {
            var q1 = new Quantity<WeightUnit>(2000, WeightUnit.GRAM);
            var q2 = new Quantity<WeightUnit>(1, WeightUnit.KILOGRAM);

            var result = q1.Divide(q2);

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void TestDivide_VolumeUnits()
        {
            var q1 = new Quantity<VolumeUnit>(1000, VolumeUnit.MILLILITRE);
            var q2 = new Quantity<VolumeUnit>(1, VolumeUnit.LITRE);

            var result = q1.Divide(q2);

            Assert.AreEqual(1, result);
        }

        // ---------- ERROR CASE TESTS ----------

        [TestMethod]
        
        public void TestAdd_NullOperand()
        {
            var q1 = new Quantity<LengthUnit>(10, LengthUnit.FEET);

            Assert.Throws<ArgumentException>(() => q1.Add(null));
        }

        [TestMethod]
        
        public void TestSubtract_NullOperand()
        {
            var q1 = new Quantity<LengthUnit>(10, LengthUnit.FEET);

            Assert.Throws<ArgumentException>(() => q1.Subtract(null));
        }

        [TestMethod]
        
        public void TestDivide_NullOperand()
        {
            var q1 = new Quantity<LengthUnit>(10, LengthUnit.FEET);

            Assert.Throws<ArgumentException>(() => q1.Divide(null));
        }

        [TestMethod]
        
        public void TestDivide_ByZero()
        {
            var q1 = new Quantity<LengthUnit>(10, LengthUnit.FEET);
            var q2 = new Quantity<LengthUnit>(0, LengthUnit.FEET);

            Assert.Throws<ArithmeticException>(() => q1.Divide(q2));
        }

        // ---------- IMMUTABILITY TEST ----------

        [TestMethod]
        public void TestImmutability_AfterAddition()
        {
            var q1 = new Quantity<LengthUnit>(10, LengthUnit.FEET);
            var q2 = new Quantity<LengthUnit>(5, LengthUnit.FEET);

            var result = q1.Add(q2);

            Assert.AreEqual(10, q1.Value);
            Assert.AreEqual(5, q2.Value);
        }

        [TestMethod]
        public void TestImmutability_AfterSubtraction()
        {
            var q1 = new Quantity<LengthUnit>(10, LengthUnit.FEET);
            var q2 = new Quantity<LengthUnit>(5, LengthUnit.FEET);

            var result = q1.Subtract(q2);

            Assert.AreEqual(10, q1.Value);
            Assert.AreEqual(5, q2.Value);
        }

        [TestMethod]
        public void TestDivision_RatioLessThanOne()
        {
            var q1 = new Quantity<LengthUnit>(5, LengthUnit.FEET);
            var q2 = new Quantity<LengthUnit>(10, LengthUnit.FEET);

            var result = q1.Divide(q2);

            Assert.AreEqual(0.5, result);
        }

    }
}