using CalculatorApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static CalculatorApp.Optional_functions;

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
        /// mg, dag, g, kg, t, lb, oz
        [TestMethod]
        public void Test_weight()
        {
            Assert.ThrowsException<OverflowException>(() => root.Weight(79228162514264337593543950334m, "kg", "g"));
            Assert.ThrowsException<UndefinedUnitException>(() => root.Weight(1m, "kk", "g"));
            Assert.ThrowsException<UndefinedUnitException>(() => root.Weight(1m, "kg", "gg"));

            /// From kg
            Assert.AreEqual(123.4567m, root.Weight(123.4567m, "kg", "kg"), delta: 0);
            Assert.AreEqual(123456700m, root.Weight(123.4567m, "kg", "mg"), delta: 0);
            Assert.AreEqual(123456.7m, root.Weight(123.4567m, "kg", "g"), delta: 0);
            Assert.AreEqual(272.175433410554m, root.Weight(123.4567m, "kg", "lb"), delta: 0);
            Assert.AreEqual(0.1234567m, root.Weight(123.4567m, "kg", "t"), delta: 0);
            Assert.AreEqual(12345.67m, root.Weight(123.4567m, "kg", "dag"), delta: 0);
            Assert.AreEqual(4354.80693209973m, root.Weight(123.4567m, "kg", "oz"), delta: 0);
            /// To mg
            Assert.AreEqual(4658.1345m, root.Weight(4658.1345m, "mg", "mg"), delta: 0);
            Assert.AreEqual(4658134500m, root.Weight(4658.1345m, "kg", "mg"), delta: 0);
            Assert.AreEqual(4658134.5m, root.Weight(4658.1345m, "g", "mg"), delta: 0);
            Assert.AreEqual(2112894267.633765m, root.Weight(4658.1345m, "lb", "mg"), delta: 0);
            Assert.AreEqual(4658134500000m, root.Weight(4658.1345m, "t", "mg"), delta: 0);
            Assert.AreEqual(46581345m, root.Weight(4658.1345m, "dag", "mg"), delta: 0);
            Assert.AreEqual(132055891.61065695m, root.Weight(4658.1345m, "oz", "mg"), delta: 0);
            /// Negative
            Assert.AreEqual(-0.06825867m, root.Weight(-68.25867m, "g", "kg"), delta: 0);
            Assert.AreEqual(-30961.6118983479m, root.Weight(-68.25867m, "lb", "g"), delta: 0);
            /// Zero
            Assert.AreEqual(0m, root.Weight(0m, "g", "kg"), delta: 0);

        }
        /// <summary>
        /// Testing Length() function for length conversions
        /// </summary>
        /// mm, cm, dm, m, km, miles, inch, yard
        [TestMethod]
        public void Test_length() 
        {
            Assert.ThrowsException<OverflowException>(() => root.Length(79228162514264337593543950334m, "km", "m"));
            Assert.ThrowsException<NegativeNumberException>(() => root.Length(-5m, "km", "m"));
            Assert.ThrowsException<UndefinedUnitException>(() => root.Length(1m, "kk", "g"));
            Assert.ThrowsException<UndefinedUnitException>(() => root.Length(1m, "km", "ms"));

            /// From dm
            Assert.AreEqual(1234.567m, root.Weight(123.4567m, "cm", "mm"), delta: 0);
            Assert.AreEqual(123.4567m, root.Weight(123.4567m, "cm", "cm"), delta: 0);
            Assert.AreEqual(12.34567m, root.Weight(123.4567m, "cm", "dm"), delta: 0);
            Assert.AreEqual(1.234567m, root.Weight(123.4567m, "cm", "m"), delta: 0);
            Assert.AreEqual(0.001235m, root.Weight(123.4567m, "cm", "km"), delta: 0);
            Assert.AreEqual(0.000767m, root.Weight(123.4567m, "cm", "miles"), delta: 0);
            Assert.AreEqual(48.605m, root.Weight(123.4567m, "cm", "inch"), delta: 0);
            Assert.AreEqual(1.350139m, root.Weight(123.4567m, "cm", "yard"), delta: 0);
            /// To km
            Assert.AreEqual(123.4567m, root.Weight(98756.2586m, "mm", "km"), delta: 0);
            Assert.AreEqual(0.09875626m, root.Weight(98756.2586m, "cm", "km"), delta: 0);
            Assert.AreEqual(0.98756259m, root.Weight(98756.2586m, "dm", "km"), delta: 0);
            Assert.AreEqual(98.7562586m, root.Weight(98756.2586m, "m", "km"), delta: 0);
            Assert.AreEqual(98756.2586m, root.Weight(98756.2586m, "km", "km"), delta: 0);
            Assert.AreEqual(158932.792m, root.Weight(98756.2586m, "miles", "km"), delta: 0);
            Assert.AreEqual(2.50840897m, root.Weight(98756.2586m, "inch", "km"), delta: 0);
            Assert.AreEqual(90.3027229m, root.Weight(98756.2586m, "yard", "km"), delta: 0);
            /// Zero
            Assert.AreEqual(0m, root.Weight(0m, "mm", "km"), delta: 0);
        }
        /// <summary>
        /// Testing Time() function for time conversions
        /// </summary>
        /// sec, min, hour, days, weeks, months, years
        [TestMethod]
        public void Test_time() 
        {
            Assert.ThrowsException<OverflowException>(() => root.Time(79228162514264337593543950334m, "min", "sec"));
            Assert.ThrowsException<NegativeNumberException>(() => root.Time(-5m, "min", "sec"));
            Assert.ThrowsException<UndefinedUnitException>(() => root.Time(1m, "miy", "sec"));
            Assert.ThrowsException<UndefinedUnitException>(() => root.Time(1m, "day", "yeer"));

            /// From hour
            Assert.AreEqual(444444.1m, root.Time(123.4567m, "hour", "sec"), delta: 0);
            Assert.AreEqual(7407.402m, root.Time(123.4567m, "hour", "min"), delta: 0);
            Assert.AreEqual(1234.567m, root.Time(123.4567m, "hour", "hour"), delta: 0);
            Assert.AreEqual(5.144029m, root.Time(123.4567m, "hour", "days"), delta: 0);
            Assert.AreEqual(0.734861m, root.Time(123.4567m, "hour", "weeks"), delta: 0);
            Assert.AreEqual(0.169003m, root.Time(123.4567m, "hour", "months"), delta: 0);
            Assert.AreEqual(0.014084m, root.Time(123.4567m, "hour", "years"), delta: 0);
            /// To days
            Assert.AreEqual(1.14301225m, root.Time(98756.2586m, "sec", "days"), delta: 0);
            Assert.AreEqual(68.5807351m, root.Time(98756.2586m, "min", "days"), delta: 0);
            Assert.AreEqual(4114.84411m, root.Time(98756.2586m, "hour", "days"), delta: 0);
            Assert.AreEqual(98756.2586m, root.Time(98756.2586m, "days", "days"), delta: 0);
            Assert.AreEqual(691293.81m, root.Time(98756.2586m, "weeks", "days"), delta: 0);
            Assert.AreEqual(135.1899502m, root.Time(98756.2586m, "months", "days"), delta: 0);
            Assert.AreEqual(36070723.5m, root.Time(98756.2586m, "year", "days"), delta: 0);
            ///Zero 
            Assert.AreEqual(0m, root.Time(0m, "hour", "day"), delta: 0);
        }
        /// <summary>
        /// Testing Temp() function for temperature conversions
        /// </summary>
        /// celsius(C), fahrenheit(F), kelvin(K)
        [TestMethod]
        public void Test_temp() 
        {
            Assert.ThrowsException<OverflowException>(() => root.Temp(79228162514264337593543950334m, "C", "K"));
            Assert.ThrowsException<UndefinedUnitException>(() => root.Temp(1m, "L", "K"));
            Assert.ThrowsException<UndefinedUnitException>(() => root.Temp(1m, "C", "S"));            

            /// From C
            Assert.AreEqual(123.4567m, root.Temp(123.4567m, "C", "C"), delta: 0);
            Assert.AreEqual(254.2221m, root.Temp(123.4567m, "C", "F"), delta: 0);
            Assert.AreEqual(396.6067m, root.Temp(123.4567m, "C", "K"), delta: 0);
            /// To K
            Assert.AreEqual(4931.2845m, root.Temp(4658.1345m, "C", "K"), delta: 0);
            Assert.AreEqual(2843.2247m, root.Temp(4658.1345m, "F", "K"), delta: 0);
            Assert.AreEqual(4658.1345m, root.Temp(4658.1345m, "K", "K"), delta: 0);
            /// Negative
            Assert.AreEqual(-90.86561m, root.Temp(-68.25867m, "C", "F"), delta: 0);
            Assert.AreEqual(217.4507m, root.Temp(-68.25867m, "F", "K"), delta: 0);
            /// Zero
            Assert.AreEqual(32m, root.Temp(0m, "C", "F"), delta: 0);
        }
        /// <summary>
        /// Testing Degrees() function for plane angle conversions
        /// </summary>
        [TestMethod]
        public void Test_degrees() 
        {
            Assert.ThrowsException<OverflowException>(() => root.Degrees(79228162514264337593543950334m, "rad", "deg"));
            Assert.ThrowsException<UndefinedUnitException>(() => root.Temp(1m, "rsd", "deg"));
            Assert.ThrowsException<UndefinedUnitException>(() => root.Temp(1m, "del", "rad"));

            /// From deg
            Assert.AreEqual(123.4567m, root.Temp(123.4567m, "deg", "deg"), delta: 0);
            Assert.AreEqual(2.154726m, root.Temp(123.4567m, "deg", "rad"), delta: 0);
            /// To rad
            Assert.AreEqual(4658.1345m, root.Temp(4658.1345m, "rad", "rad"), delta: 0);
            Assert.AreEqual(266891.45m, root.Temp(4658.1345m, "rad", "deg"), delta: 0);
            /// Negative
            Assert.AreEqual(-1.191339m, root.Temp(-68.25867m, "deg", "rad"), delta: 0);
            Assert.AreEqual(-3910.934m, root.Temp(-68.25867m, "rad", "deg"), delta: 0);
            /// Zero
            Assert.AreEqual(0m, root.Temp(0m, "deg", "rad"), delta: 0);
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
