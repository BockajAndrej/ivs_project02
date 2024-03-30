using CalculatorApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Security.Principal;

namespace UnitTestCalculator
{
    [TestClass]
    public class UnitTest1
    {
        // Create an instance to test:
        Math_lib root = new Math_lib();
        decimal[] input1 = new decimal[] { -5.123456789101112131415161718m, 0m, 87.8495m, 7m / 6m, 6, 101 };


        [TestMethod]
        public void Test_Count()
        {
            Assert.AreEqual(-10.246913578202224262830323436m, root.Add(input1[0], input1[0]), delta: 0);
            Assert.AreNotEqual(-10.246913578202224262830323437m, root.Add(input1[0], input1[0]), delta: 0);
            Assert.AreEqual(-5.123456789101112131415161718m, root.Add(input1[0], input1[1]), delta: 0);
            Assert.AreEqual(82.72604321089888786858483828m, root.Add(input1[0], input1[2]), delta: 0);
            Assert.AreEqual(-3.9567901224344454647484950513m, root.Add(input1[0], input1[3]), delta: 0);
            Assert.ThrowsException<OverflowException>(() => root.Add(79228162514264337593543950334m, 12.234m));
        }
        [TestMethod]
        public void Test_Subtraction()
        {
            Assert.AreEqual(0m, root.Substraction(input1[0], input1[0]), delta: 0);
            Assert.AreEqual(-5.123456789101112131415161718m, root.Substraction(input1[0], input1[1]), delta: 0);
            Assert.AreNotEqual(-5.123456789101112131415161717m, root.Substraction(input1[0], input1[1]), delta: 0);
            Assert.AreEqual(-92.972956789101112131415161718m, root.Substraction(input1[0], input1[2]), delta: 0);
            Assert.AreEqual(-6.2901234557677787980818283847m, root.Substraction(input1[0], input1[3]), delta: 0);
            Assert.ThrowsException<OverflowException>(() => root.Substraction(-20.5m, 79228162514264337593543950334m));
        }
        [TestMethod]
        public void Test_Multiplication()
        {
            Assert.AreEqual(26.249809469786277793308764626m, root.Multiplication(input1[0], input1[0]), delta: 0.00000000000000000000000001m);
            Assert.AreNotEqual(26.24980946978627779330876465m, root.Multiplication(input1[0], input1[0]), delta: 0.00000000000000000000000001m);
            Assert.AreEqual(0m, root.Multiplication(input1[0], input1[1]), delta: 0.00000000000000000000000001m);
            Assert.AreEqual(-450.0931171941381501887562493454m, root.Multiplication(input1[0], input1[2]), delta: 0.00000000000000000000000001m);
            Assert.AreEqual(-5.977366253951297486651022004m, root.Multiplication(input1[0], input1[3]), delta: 0.00000000000000000000000001m);
            Assert.ThrowsException<OverflowException>(() => root.Multiplication(79228162514264337593543950334m, 50.2m));
        }
        [TestMethod]
        public void Test_Division()
        {
            Assert.AreEqual(1m, root.Division(input1[0], input1[0]), delta: 0.00000000000000000000000001m);
            Assert.AreEqual(-0.058320841770313002708213042966m, root.Division(input1[0], input1[2]), delta: 0.00000000000000000000000001m);
            Assert.AreNotEqual(-0.058320841770313002708313052966m, root.Division(input1[0], input1[2]), delta: 0.00000000000000000000000001m);
            Assert.AreEqual(-4.391534390658096112641567186m, root.Division(input1[0], input1[3]), delta: 0.00000000000000000000000001m);
            Assert.ThrowsException<DivideByZeroException>(() => root.Division(5m, 0m));
        }
        public void Test_Modulo()
        {
            Assert.AreEqual(0m, root.Modulo(input1[0], input1[0]), delta: 0m);
            Assert.AreEqual(0.8765432109m, root.Modulo(input1[0], 2), delta: 0.0000000001m);
            Assert.AreEqual(-4.3727222038m, root.Modulo(input1[2], input1[0]), delta: 0.0000000001m);
            Assert.AreNotEqual(3.8495m, root.Modulo(input1[2], input1[4]), delta: 0.0000000001m);
            Assert.ThrowsException<DivideByZeroException>(() => root.Modulo(5m, 0m));
        }
        [TestMethod]
        public void Test_Faktorial()
        {
            //accuracy to 10 decimal places
            Assert.ThrowsException<NegativeFactorialException>(() => root.Faktorial(input1[0]));
            Assert.AreEqual(1m, root.Faktorial(input1[1]), delta: 0.0000000001m);
            Assert.AreNotEqual(0m, root.Faktorial(input1[1]), delta: 0.0000000001m);
            Assert.AreEqual(1.08233922257m, root.Faktorial(input1[3]), delta: 0.0000000001m);
            Assert.AreEqual(720m, root.Faktorial(input1[4]), delta: 0m);
            Assert.ThrowsException<OverflowException>(() => root.Faktorial(input1[5]));
        }
        [TestMethod]
        public void Test_EXP()
        {
            Assert.ThrowsException<NonNaturalExponentException>(() => root.Exponentiation(input1[0], input1[0]));
            Assert.AreEqual(-26.249809469786277793308764626359m, root.Exponentiation(input1[0], input1[1]), delta: 0.00000000000000000000000001m);
            Assert.AreNotEqual(-26.249809469786277763308764626359m, root.Exponentiation(input1[0], input1[1]), delta: 0.00000000000000000000000001m);
            Assert.AreEqual(1061520150601m, root.Exponentiation(input1[5], input1[4]), delta: 0.00000000000000000000000001m);
            Assert.ThrowsException<OverflowException>(() => root.Exponentiation(input1[5], input1[4]));
        }
        [TestMethod]
        public void Test_SQRT()
        {
            Assert.ThrowsException<NegativeRootException>(() => root.Exponentiation(input1[0], input1[4]));
            Assert.ThrowsException<NegativeRootException>(() => root.Exponentiation(input1[4], input1[0]));
            Assert.ThrowsException<NegativeRootException>(() => root.Exponentiation(input1[0], input1[1]));
            Assert.AreEqual(-1.723935551553132419949721178881m, root.Exponentiation(input1[0], 3), delta: 0.00000000000000000000000001m);
            Assert.AreNotEqual(-1.723935551554132419949721178881m, root.Exponentiation(input1[0], 3), delta: 0.00000000000000000000000001m);
            Assert.AreEqual(2.1580105439510335m, root.Exponentiation(input1[5], input1[4]), delta: 0.00000000000000000000000001m);
            Assert.AreEqual(1m, root.Exponentiation(1, 5), delta: 0m);
            Assert.AreEqual(0m, root.Exponentiation(0, 4), delta: 0m);
        }
    }
}
