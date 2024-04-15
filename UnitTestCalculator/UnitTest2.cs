using CalculatorApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestCalculator
{
    /// <summary>
    /// Tests for Optional_functions.cs class
    /// </summary>
    [TestClass]
    public class UnitTest2
    {
        // Create an instance to test:
        Optional_functions root = new Optional_functions();
        /// <summary>
        /// Testing Weight() function for weight conversions 
        /// </summary>
        [TestMethod]
        public void Test_weight()
        {
            Assert.ThrowsException<OverflowException>(() => root.Weight(79228162514264337593543950334m, "kg", "g"));
            Assert.AreEqual(12m, root.Weight(12m, "kg", "kg"), delta: 0);
        }
        /// <summary>
        /// Testing Length() function for length conversions
        /// </summary>
        [TestMethod]
        public void Test_length() 
        {
            Assert.ThrowsException<OverflowException>(() => root.Length(79228162514264337593543950334m, "km", "m"));
            Assert.AreEqual(12m, root.Length(12m, "kg", "kg"), delta: 0);
        }
        /// <summary>
        /// Testing Time() function for time conversions
        /// </summary>
        [TestMethod]
        public void Test_time() 
        {
            Assert.ThrowsException<OverflowException>(() => root.Time(79228162514264337593543950334m, "min", "sec"));
            Assert.AreEqual(12m, root.Time(12m, "kg", "kg"), delta: 0);
        }
        /// <summary>
        /// Testing Temp() function for temperature conversions
        /// </summary>
        [TestMethod]
        public void Test_temp() 
        {
            Assert.ThrowsException<OverflowException>(() => root.Temp(79228162514264337593543950334m, "C", "K"));
            Assert.AreEqual(12m, root.Temp(12m, "kg", "kg"), delta: 0);
        }
        /// <summary>
        /// Testing Degrees() function for plane angle conversions
        /// </summary>
        [TestMethod]
        public void Test_degrees() 
        {
            Assert.ThrowsException<OverflowException>(() => root.Degrees(79228162514264337593543950334m, "rad", "C"));
            Assert.AreEqual(12m, root.Degrees(12m, "kg", "kg"), delta: 0);
        }
        /// <summary>
        /// Testing Density() function for density conversions
        /// </summary>
        [TestMethod]
        public void Test_density()
        {
            //Assert.ThrowsException<OverflowException>(() => root.Density(79228162514264337593543950334m, "rad", "C"));
            //Assert.AreEqual(12m, root.Density(12m, "kg", "kg"), delta: 0);
        }
        /// <summary>
        /// Testing Performance() function for performance conversions
        /// </summary>
        [TestMethod]
        public void Test_power()
        {
            //Assert.ThrowsException<OverflowException>(() => root.Performance(79228162514264337593543950334m, "rad", "C"));
            //Assert.AreEqual(12m, root.Performance(12m, "kg", "kg"), delta: 0);
        }
        /// <summary>
        /// Testing Energy() function for energy conversions
        /// </summary>
        [TestMethod]
        public void Test_energy()
        {
            //Assert.ThrowsException<OverflowException>(() => root.Energy(79228162514264337593543950334m, "rad", "C"));
            //Assert.AreEqual(12m, root.Energy(12m, "kg", "kg"), delta: 0);
        }
        /// <summary>
        /// Testing Speed() function for speed conversions
        /// </summary>
        [TestMethod]
        public void Test_speed()
        {
            //Assert.ThrowsException<OverflowException>(() => root.Speed(79228162514264337593543950334m, "rad", "C"));
            //Assert.AreEqual(12m, root.Speed(12m, "kg", "kg"), delta: 0);
        }
    }
}
