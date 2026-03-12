using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.models;

namespace QuantityMeasurementApp.Tests
{
    [TestClass]
    public class VolumeUnitTests
    {

        [TestMethod]
        public void TestEquality_LitreToLitre()
        {
            var v1 = new Quantity<VolumeUnit>(1, VolumeUnit.LITRE);
            var v2 = new Quantity<VolumeUnit>(1, VolumeUnit.LITRE);

            Assert.IsTrue(v1.Equals(v2));
        }

        [TestMethod]
        public void TestEquality_LitreToMillilitre()
        {
            var v1 = new Quantity<VolumeUnit>(1, VolumeUnit.LITRE);
            var v2 = new Quantity<VolumeUnit>(1000, VolumeUnit.MILLILITRE);

            Assert.IsTrue(v1.Equals(v2));
        }

        [TestMethod]
        public void TestEquality_GallonToLitre()
        {
            var v1 = new Quantity<VolumeUnit>(1, VolumeUnit.GALLON);
            var v2 = new Quantity<VolumeUnit>(3.78541, VolumeUnit.LITRE);

            Assert.IsTrue(v1.Equals(v2));
        }

        [TestMethod]
        public void TestConversion_LitreToMillilitre()
        {
            var v = new Quantity<VolumeUnit>(1, VolumeUnit.LITRE);

            var result = v.ConvertTo(VolumeUnit.MILLILITRE);

            Assert.AreEqual(1000, result.Value);
        }

        [TestMethod]
        public void TestConversion_GallonToLitre()
        {
            var v = new Quantity<VolumeUnit>(1, VolumeUnit.GALLON);

            var result = v.ConvertTo(VolumeUnit.LITRE);

            Assert.AreEqual(3.78541, result.Value);
        }

        [TestMethod]
        public void TestAddition_LitrePlusMillilitre()
        {
            var v1 = new Quantity<VolumeUnit>(1, VolumeUnit.LITRE);
            var v2 = new Quantity<VolumeUnit>(1000, VolumeUnit.MILLILITRE);

            var result = v1.Add(v2);

            Assert.AreEqual(2, result.Value);
        }

        [TestMethod]
        public void TestAddition_LitrePlusGallon()
        {
            var v1 = new Quantity<VolumeUnit>(1, VolumeUnit.LITRE);
            var v2 = new Quantity<VolumeUnit>(1, VolumeUnit.GALLON);

            var result = v1.Add(v2, VolumeUnit.LITRE);

            Assert.AreEqual(4.78541, result.Value);
        }

        [TestMethod]
        public void TestAddition_ExplicitTargetUnit()
        {
            var v1 = new Quantity<VolumeUnit>(1, VolumeUnit.LITRE);
            var v2 = new Quantity<VolumeUnit>(1000, VolumeUnit.MILLILITRE);

            var result = v1.Add(v2, VolumeUnit.MILLILITRE);

            Assert.AreEqual(2000, result.Value);
        }
    }
}