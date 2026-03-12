using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.models;

namespace QuantityMeasurementApp.Tests
{
    [TestClass]
    public class QuantityArithmeticTests
    {

        [TestMethod]
        public void TestSubtraction_SameUnit()
        {
            var q1 = new Quantity<LengthUnit>(10, LengthUnit.FEET);
            var q2 = new Quantity<LengthUnit>(5, LengthUnit.FEET);

            var result = q1.Subtract(q2);

            Assert.AreEqual(5, result.Value);
        }

        [TestMethod]
        public void TestSubtraction_CrossUnit()
        {
            var q1 = new Quantity<LengthUnit>(10, LengthUnit.FEET);
            var q2 = new Quantity<LengthUnit>(6, LengthUnit.INCH);

            var result = q1.Subtract(q2);

            Assert.AreEqual(9.5, result.Value);
        }

        [TestMethod]
        public void TestSubtraction_ExplicitTargetUnit()
        {
            var q1 = new Quantity<LengthUnit>(10, LengthUnit.FEET);
            var q2 = new Quantity<LengthUnit>(6, LengthUnit.INCH);

            var result = q1.Subtract(q2, LengthUnit.INCH);

            Assert.AreEqual(114, result.Value);
        }

        [TestMethod]
        public void TestSubtraction_ResultNegative()
        {
            var q1 = new Quantity<LengthUnit>(5, LengthUnit.FEET);
            var q2 = new Quantity<LengthUnit>(10, LengthUnit.FEET);

            var result = q1.Subtract(q2);

            Assert.AreEqual(-5, result.Value);
        }

        [TestMethod]
        public void TestDivision_SameUnit()
        {
            var q1 = new Quantity<LengthUnit>(10, LengthUnit.FEET);
            var q2 = new Quantity<LengthUnit>(2, LengthUnit.FEET);

            var result = q1.Divide(q2);

            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void TestDivision_CrossUnit()
        {
            var q1 = new Quantity<LengthUnit>(24, LengthUnit.INCH);
            var q2 = new Quantity<LengthUnit>(2, LengthUnit.FEET);

            var result = q1.Divide(q2);

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void TestDivision_ByZero()
        {
            var q1 = new Quantity<LengthUnit>(10, LengthUnit.FEET);
            var q2 = new Quantity<LengthUnit>(0, LengthUnit.FEET);

            Assert.Throws<ArithmeticException>(() => q1.Divide(q2)); 
        }

        [TestMethod]
        public void TestDivision_RatioLessThanOne()
        {
            var q1 = new Quantity<LengthUnit>(5, LengthUnit.FEET);
            var q2 = new Quantity<LengthUnit>(10, LengthUnit.FEET);

            var result = q1.Divide(q2);

            Assert.AreEqual(0.5, result);
        }

        [TestMethod]
        public void TestDivision_RatioEqualToOne()
        {
            var q1 = new Quantity<LengthUnit>(10, LengthUnit.FEET);
            var q2 = new Quantity<LengthUnit>(10, LengthUnit.FEET);

            var result = q1.Divide(q2);

            Assert.AreEqual(1, result);
        }
    }
}