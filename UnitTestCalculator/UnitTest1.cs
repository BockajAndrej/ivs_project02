using CalculatorApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Security.Principal;

namespace UnitTestCalculator
{
    /// <summary>
    /// Tests for Math_lib.cs
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        // Create an instance to test:
        Math_lib root = new Math_lib();

        /// <summary>
        /// Testing Add() function for Add arithmetics operation
        /// </summary>
        /// <exception cref="OverflowException"></exception>
        [TestMethod]
        public void Test_Count()
        {
            Assert.ThrowsException<OverflowException>(() => root.Add(79228162514264337593543950334m, 12.234m));
            Assert.AreEqual(-10.246913578202224262830323436m, root.Add(-5.123456789101112131415161718m, -5.123456789101112131415161718m), delta: 0);
            Assert.AreNotEqual(-10.246913578202224262830323437m, root.Add(-5.123456789101112131415161718m, -5.123456789101112131415161718m), delta: 0);
            Assert.AreEqual(-5.123456789101112131415161718m, root.Add(-5.123456789101112131415161718m, 0m), delta: 0);
            Assert.AreEqual(82.72604321089888786858483828m, root.Add(-5.123456789101112131415161718m, 87.8495m), delta: 0);
            Assert.AreEqual(-3.9567901224344454647484950513m, root.Add(-5.123456789101112131415161718m, 7m / 6m), delta: 0);
        }
        /// <summary>
        /// Testing Substraction() function for Substraction arithmetics operation
        /// </summary>
        /// <exception cref="OverflowException"></exception>
        [TestMethod]
        public void Test_Subtraction()
        {
            Assert.ThrowsException<OverflowException>(() => root.Substraction(-20.5m, 79228162514264337593543950334m));
            Assert.AreEqual(0m, root.Substraction(-5.123456789101112131415161718m, -5.123456789101112131415161718m), delta: 0);
            Assert.AreEqual(-5.123456789101112131415161718m, root.Substraction(-5.123456789101112131415161718m, 0m), delta: 0);
            Assert.AreNotEqual(-5.123456789101112131415161717m, root.Substraction(-5.123456789101112131415161718m, 0m), delta: 0);
            Assert.AreEqual(-92.972956789101112131415161718m, root.Substraction(-5.123456789101112131415161718m, 87.8495m), delta: 0);
            Assert.AreEqual(-6.2901234557677787980818283847m, root.Substraction(-5.123456789101112131415161718m, 7m / 6m), delta: 0);
        }
        /// <summary>
        /// Testing Multiplication() function for Multiplication arithmetics operation
        /// </summary>
        /// <exception cref="OverflowException"></exception>
        [TestMethod]
        public void Test_Multiplication()
        {
            Assert.ThrowsException<OverflowException>(() => root.Multiplication(79228162514264337593543950334m, 50.2m));
            Assert.AreEqual(26.249809469786277793308764626m, root.Multiplication(-5.123456789101112131415161718m, -5.123456789101112131415161718m), delta: 0.00000000000000000000000001m);
            Assert.AreNotEqual(26.24980946978627779330876465m, root.Multiplication(-5.123456789101112131415161718m, -5.123456789101112131415161718m), delta: 0.00000000000000000000000001m);
            Assert.AreEqual(0m, root.Multiplication(-5.123456789101112131415161718m, 0m), delta: 0.00000000000000000000000001m);
            Assert.AreEqual(-450.0931171941381501887562493454m, root.Multiplication(-5.123456789101112131415161718m, 87.8495m), delta: 0.00000000000000000000000001m);
            Assert.AreEqual(-5.977366253951297486651022004m, root.Multiplication(-5.123456789101112131415161718m, 7m / 6m), delta: 0.00000000000000000000000001m);
        }
        /// <summary>
        /// Testing Division() function for Division arithmetics operation
        /// </summary>
        /// <exception cref="DivideByZeroException"></exception>
        /// <exception cref="OverflowException"></exception>
        [TestMethod]
        public void Test_Division()
        {
            Assert.ThrowsException<DivideByZeroException>(() => root.Division(5m, 0m));
            Assert.ThrowsException<OverflowException>(() => root.Division(79228162514264337593543950334m, 0.1m));
            Assert.AreEqual(1m, root.Division(-5.123456789101112131415161718m, -5.123456789101112131415161718m), delta: 0.00000000000000000000000001m);
            Assert.AreEqual(-0.058320841770313002708213042966m, root.Division(-5.123456789101112131415161718m, 87.8495m), delta: 0.00000000000000000000000001m);
            Assert.AreNotEqual(-0.058320841770313002708313052966m, root.Division(-5.123456789101112131415161718m, 87.8495m), delta: 0.00000000000000000000000001m);
            Assert.AreEqual(-4.391534390658096112641567186m, root.Division(-5.123456789101112131415161718m, 7m / 6m), delta: 0.00000000000000000000000001m);
        }
        /// <summary>
        /// Testing Modulo() function for remainder after division
        /// </summary>
        /// <exception cref="DivideByZeroException"></exception>
        [TestMethod]
        public void Test_Modulo()
        {
            Assert.ThrowsException<DivideByZeroException>(() => root.Modulo(5m, 0m));
            Assert.AreEqual(0m, root.Modulo(-5.123456789101112131415161718m, -5.123456789101112131415161718m), delta: 0m);
            Assert.AreEqual(0.8765432109m, root.Modulo(-5.123456789101112131415161718m, 2), delta: 0.0000000001m);
            Assert.AreEqual(-4.3727222038m, root.Modulo(87.8495m, -5.123456789101112131415161718m), delta: 0.000000001m);
        }
        /// <summary>
        /// Testing Faktorial() function for faktorial arithmetics operation
        /// </summary>
        /// <exception cref="NegativeFactorialException"></exception>
        /// <exception cref="OverflowException"></exception>
        [TestMethod]
        public void Test_Faktorial()
        {
            //accuracy to 10 decimal places
            Assert.ThrowsException<NegativeFactorialException>(() => root.Faktorial(-5.123456789101112131415161718m));
            Assert.ThrowsException<OverflowException>(() => root.Faktorial(101m));
            Assert.ThrowsException<OverflowException>(() => root.Faktorial(28));
            Assert.AreEqual(1m, root.Faktorial(0m), delta: 0.0000000001m);
            Assert.AreNotEqual(0m, root.Faktorial(0m), delta: 0.0000000001m);
            //Assert.AreEqual(1.08233922257m, root.Faktorial(7m / 6m), delta: 0.0000000001m);
            Assert.AreEqual(720m, root.Faktorial(6m), delta: 0m);
            Assert.AreEqual(121645100408832000, root.Faktorial(19));
        }
        /// <summary>
        /// Testing Exponentiation() function for exponentiation arithmetics operation
        /// </summary>
        /// <exception cref="NonNaturalExponentException"></exception>
        /// <exception cref="OverflowException"></exception>
        [TestMethod]
        public void Test_EXP()
        {
            Assert.ThrowsException<NonNaturalExponentException>(() => root.Exponentiation(-5.123456789101112131415161718m, -5.123456789101112131415161718m));
            Assert.ThrowsException<OverflowException>(() => root.Exponentiation(6m, 101m));
            Assert.AreEqual(1m, root.Exponentiation(-5.123456789101112131415161718m, 0m), delta: 0m);
            Assert.AreNotEqual(-1m, root.Exponentiation(-5.123456789101112131415161718m, 0m), delta: 0.00000000000000000000000001m);
            Assert.AreEqual(18087.496766182577993629018063720913m, root.Exponentiation(-5.123456789101112131415161718m, 6m), delta: 0.00000000000000000000000001m);
            Assert.AreEqual(-3530.3306948268318326739591958m, root.Exponentiation(-5.123456789101112131415161718m, 5), delta: 0.00000000000000000000000001m);
            Assert.AreEqual(1061520150601m, root.Exponentiation(101m, 6m), delta: 0.00000000000000000000000001m);
        }
        /// <summary>
        /// Testing SquareRoot() function for squareRoot arithmetics operation
        /// </summary>
        /// <exception cref="NegativeRootException"></exception>
        [TestMethod]
        public void Test_SQRT()
        {
            //Tests for sqrt with 1 param.
            Assert.ThrowsException<NegativeRootException>(() => root.SquareRoot(-5.123456789101112131415161718m));
            Assert.ThrowsException<NegativeRootException>(() => root.SquareRoot(-5));
            Assert.AreEqual(0m, root.SquareRoot(0m), delta: 0m);
            Assert.AreEqual(1m, root.SquareRoot(1m), delta: 0m);
            Assert.AreEqual(2, root.SquareRoot(4), delta: 0.0000000000000001m);
            Assert.AreEqual(4, root.SquareRoot(16), delta: 0.0000000000000001m);
            Assert.AreEqual(8, root.SquareRoot(64), delta: 0.0000000000000001m);
            Assert.AreEqual(3.8729833462074168852m, root.SquareRoot(15), delta: 0.0000000000000001m);
            Assert.AreEqual(31.622776601683793319m, root.SquareRoot(1000), delta: 0.0000000000000001m);
            Assert.AreEqual(0.7071067811865475244m, root.SquareRoot(0.5m), delta: 0.0000000000000001m);
            Assert.AreEqual(4.5825756949558400065m, root.SquareRoot(21), delta: 0.0000000000000001m);
            Assert.AreEqual(0.3162277660168379331m, root.SquareRoot(0.1m), delta: 0.0000000000000001m);
            Assert.AreEqual(223.60679774997896964m, root.SquareRoot(50000), delta: 0.0000000000000001m);
        }
    }
}
