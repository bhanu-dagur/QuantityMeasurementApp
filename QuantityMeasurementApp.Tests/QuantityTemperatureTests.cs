using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Tests
{
    [TestClass]
    public class QuantityTemperatureTests
    {

        // ---------- Equality Tests ----------

        [TestMethod]
        public void TestTemperatureEquality_CelsiusSameValue()
        {
            var t1 = new Quantity<TemperatureUnit>(0, TemperatureUnit.CELSIUS);
            var t2 = new Quantity<TemperatureUnit>(0, TemperatureUnit.CELSIUS);

            Assert.IsTrue(t1.Equals(t2));
        }

        [TestMethod]
        public void TestTemperatureEquality_FahrenheitSameValue()
        {
            var t1 = new Quantity<TemperatureUnit>(32, TemperatureUnit.FAHRENHEIT);
            var t2 = new Quantity<TemperatureUnit>(32, TemperatureUnit.FAHRENHEIT);

            Assert.IsTrue(t1.Equals(t2));
        }

        [TestMethod]
        public void TestTemperatureEquality_CelsiusToFahrenheit()
        {
            var t1 = new Quantity<TemperatureUnit>(0, TemperatureUnit.CELSIUS);
            var t2 = new Quantity<TemperatureUnit>(32, TemperatureUnit.FAHRENHEIT);

            Assert.IsTrue(t1.Equals(t2));
        }

        [TestMethod]
        public void TestTemperatureEquality_100Celsius_212Fahrenheit()
        {
            var t1 = new Quantity<TemperatureUnit>(100, TemperatureUnit.CELSIUS);
            var t2 = new Quantity<TemperatureUnit>(212, TemperatureUnit.FAHRENHEIT);

            Assert.IsTrue(t1.Equals(t2));
        }

        [TestMethod]
        public void TestTemperatureEquality_Negative40Same()
        {
            var t1 = new Quantity<TemperatureUnit>(-40, TemperatureUnit.CELSIUS);
            var t2 = new Quantity<TemperatureUnit>(-40, TemperatureUnit.FAHRENHEIT);

            Assert.IsTrue(t1.Equals(t2));
        }

        [TestMethod]
        public void TestTemperatureEquality_Reflexive()
        {
            var t = new Quantity<TemperatureUnit>(50, TemperatureUnit.CELSIUS);

            Assert.IsTrue(t.Equals(t));
        }

        [TestMethod]
        public void TestTemperatureEquality_Inequality()
        {
            var t1 = new Quantity<TemperatureUnit>(50, TemperatureUnit.CELSIUS);
            var t2 = new Quantity<TemperatureUnit>(100, TemperatureUnit.CELSIUS);

            Assert.IsFalse(t1.Equals(t2));
        }

        // ---------- Conversion Tests ----------

        [TestMethod]
        public void TestConversion_CelsiusToFahrenheit()
        {
            var t = new Quantity<TemperatureUnit>(100, TemperatureUnit.CELSIUS);

            var result = t.ConvertTo(TemperatureUnit.FAHRENHEIT);

            Assert.AreEqual(212, result.Value);
        }

        [TestMethod]
        public void TestConversion_FahrenheitToCelsius()
        {
            var t = new Quantity<TemperatureUnit>(32, TemperatureUnit.FAHRENHEIT);

            var result = t.ConvertTo(TemperatureUnit.CELSIUS);

            Assert.AreEqual(0, result.Value);
        }

        [TestMethod]
        public void TestConversion_CelsiusToKelvin()
        {
            var t = new Quantity<TemperatureUnit>(0, TemperatureUnit.CELSIUS);

            var result = t.ConvertTo(TemperatureUnit.KELVIN);

            Assert.AreEqual(273.15, result.Value);
        }

        [TestMethod]
        public void TestConversion_KelvinToCelsius()
        {
            var t = new Quantity<TemperatureUnit>(273.15, TemperatureUnit.KELVIN);

            var result = t.ConvertTo(TemperatureUnit.CELSIUS);

            Assert.AreEqual(0, result.Value);
        }

        [TestMethod]
        public void TestConversion_SameUnit()
        {
            var t = new Quantity<TemperatureUnit>(25, TemperatureUnit.CELSIUS);

            var result = t.ConvertTo(TemperatureUnit.CELSIUS);

            Assert.AreEqual(25, result.Value);
        }

        // ---------- Unsupported Arithmetic ----------

        [TestMethod]
        
        public void TestTemperatureUnsupported_Addition()
        {
            var t1 = new Quantity<TemperatureUnit>(100, TemperatureUnit.CELSIUS);
            var t2 = new Quantity<TemperatureUnit>(50, TemperatureUnit.CELSIUS);

            Assert.Throws<ArgumentException>(() => t1.Add(t2));
            
        }

        [TestMethod]
       
        public void TestTemperatureUnsupported_Subtraction()
        {
            var t1 = new Quantity<TemperatureUnit>(100, TemperatureUnit.CELSIUS);
            var t2 = new Quantity<TemperatureUnit>(50, TemperatureUnit.CELSIUS);

            Assert.Throws<ArgumentException>(() => t1.Subtract(t2));
        }

        [TestMethod]
        
        public void TestTemperatureUnsupported_Division()
        {
            var t1 = new Quantity<TemperatureUnit>(100, TemperatureUnit.CELSIUS);
            var t2 = new Quantity<TemperatureUnit>(50, TemperatureUnit.CELSIUS);

            Assert.Throws<ArgumentException>(() => t1.Divide(t2));
        }

        // ---------- Cross Category Safety ----------

        [TestMethod]
        public void TestTemperatureVsLength()
        {
            var temp = new Quantity<TemperatureUnit>(100, TemperatureUnit.CELSIUS);
            var length = new Quantity<LengthUnit>(100, LengthUnit.FEET);

            Assert.IsFalse(temp.Equals(length));
        }

        [TestMethod]
        public void TestTemperatureVsWeight()
        {
            var temp = new Quantity<TemperatureUnit>(50, TemperatureUnit.CELSIUS);
            var weight = new Quantity<WeightUnit>(50, WeightUnit.KILOGRAM);

            Assert.IsFalse(temp.Equals(weight));
        }

        [TestMethod]
        public void TestTemperatureVsVolume()
        {
            var temp = new Quantity<TemperatureUnit>(25, TemperatureUnit.CELSIUS);
            var volume = new Quantity<VolumeUnit>(25, VolumeUnit.LITRE);

            Assert.IsFalse(temp.Equals(volume));
        }

        // ---------- Edge Cases ----------

        [TestMethod]
        public void TestAbsoluteZero()
        {
            var t1 = new Quantity<TemperatureUnit>(-273.15, TemperatureUnit.CELSIUS);
            var t2 = new Quantity<TemperatureUnit>(0, TemperatureUnit.KELVIN);

            Assert.IsTrue(t1.Equals(t2));
        }

        [TestMethod]
        public void TestLargeTemperatureValue()
        {
            var t = new Quantity<TemperatureUnit>(1000, TemperatureUnit.CELSIUS);

            var result = t.ConvertTo(TemperatureUnit.FAHRENHEIT);

            Assert.AreEqual(1832, result.Value);
        }

        [TestMethod]
        public void TestNegativeTemperature()
        {
            var t = new Quantity<TemperatureUnit>(-20, TemperatureUnit.CELSIUS);

            var result = t.ConvertTo(TemperatureUnit.FAHRENHEIT);

            Assert.AreEqual(-4, result.Value);
        }

        // ---------- Enum Behavior ----------

        [TestMethod]
        public void TestTemperatureUnitEnum()
        {
            Assert.AreEqual("CELSIUS", TemperatureUnit.CELSIUS.ToString());
        }

        [TestMethod]
        public void TestTemperatureSupportsArithmetic()
        {
            Assert.IsFalse(TemperatureUnit.CELSIUS.SupportsArithmetic());
        }

    }
}