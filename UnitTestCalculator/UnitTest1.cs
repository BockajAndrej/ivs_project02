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
            Assert.AreEqual(-10.246913578202224262830323436m, root.Count(input1[0], input1[0]), delta: 0);
            Assert.AreNotEqual(-10.246913578202224262830323437m, root.Count(input1[0], input1[0]), delta: 0);
            Assert.AreEqual(-5.123456789101112131415161718m, root.Count(input1[0], input1[1]), delta: 0);
            Assert.AreNotEqual(-5.123456789101112131415161717m, root.Count(input1[0], input1[1]), delta: 0);
            Assert.AreEqual(82.72604321089888786858483828m, root.Count(input1[0], input1[2]), delta: 0);
            Assert.AreNotEqual(82.72604321089888786858483829m, root.Count(input1[0], input1[2]), delta: 0);
            Assert.AreEqual(-3.9567901224344454647484950513m, root.Count(input1[0], input1[3]), delta: 0);
            Assert.AreNotEqual(-3.9567901224344454647484950514m, root.Count(input1[0], input1[3]), delta: 0);
        }
        [TestMethod]
        public void Test_subtraction()
        {
            Assert.AreEqual(0m, root.Substraction(input1[0], input1[0]), delta: 0);
            Assert.AreNotEqual(0.00000000000001m, root.Substraction(input1[0], input1[0]), delta: 0);
            Assert.AreEqual(-5.123456789101112131415161718m, root.Substraction(input1[0], input1[1]), delta: 0);
            Assert.AreNotEqual(-5.123456789101112131415161717m, root.Substraction(input1[0], input1[1]), delta: 0);
            Assert.AreEqual(-92.972956789101112131415161718m, root.Substraction(input1[0], input1[2]), delta: 0);
            Assert.AreNotEqual(-92.9729567891011121314151617m, root.Substraction(input1[0], input1[2]), delta: 0);
            Assert.AreEqual(-6.2901234557677787980818283847m, root.Substraction(input1[0], input1[3]), delta: 0);
            Assert.AreNotEqual(-6.2901234557677787980818283846m, root.Substraction(input1[0], input1[3]), delta: 0);
        }
        [TestMethod]
        public void Test_multiplication()
        {
            Assert.AreEqual(26.249809469786277793308764626m, root.Multiplication(input1[0], input1[0]), delta: 0.00000000000000000000000001m);
            Assert.AreNotEqual(26.24980946978627779330876465m, root.Multiplication(input1[0], input1[0]), delta: 0.00000000000000000000000001m);
            Assert.AreEqual(0m, root.Multiplication(input1[0], input1[1]), delta: 0.00000000000000000000000001m);
            Assert.AreNotEqual(-5.123456789101112131415161718m, root.Multiplication(input1[0], input1[1]), delta: 0.00000000000000000000000001m);
            Assert.AreEqual(-450.0931171941381501887562493454m, root.Multiplication(input1[0], input1[2]), delta: 0.00000000000000000000000001m);
            Assert.AreNotEqual(450.0931171941381501887562493444m, root.Multiplication(input1[0], input1[2]), delta: 0.00000000000000000000000001m);
            Assert.AreEqual(-5.977366253951297486651022004m, root.Multiplication(input1[0], input1[3]), delta: 0.00000000000000000000000001m);
            Assert.AreNotEqual(-5.9773662539512974866510226m, root.Multiplication(input1[0], input1[3]), delta: 0.00000000000000000000000001m);
        }
        [TestMethod]
        public void Test_division()
        {
            Assert.AreEqual(1m, root.Division(input1[0], input1[0]), delta: 0.00000000000000000000000001m);
            Assert.AreNotEqual(0m, root.Division(input1[0], input1[0]), delta: 0.00000000000000000000000001m);
            Assert.AreEqual(-0.058320841770313002708213042966m, root.Division(input1[0], input1[2]), delta: 0.00000000000000000000000001m);
            Assert.AreNotEqual(-0.058320841770313002708313052966m, root.Division(input1[0], input1[2]), delta: 0.00000000000000000000000001m);
            Assert.AreEqual(-4.391534390658096112641567186m, root.Division(input1[0], input1[3]), delta: 0.00000000000000000000000001m);
            Assert.AreNotEqual(-4.39153439065809611264157719m, root.Division(input1[0], input1[3]), delta: 0.00000000000000000000000001m);
            Assert.ThrowsException<DivideByZeroException>(() => root.Division(5m, 0m));
        }
        [TestMethod]
        public void Test_Faktorial()
        {
            //accuracy to 10 decimal places
            Assert.ThrowsException<NegativeFactorialException>(() => root.Faktorial(input1[0]));
            Assert.AreEqual(1m, root.Faktorial(input1[1]), delta: 0.0000000001m);
            Assert.AreNotEqual(0m, root.Faktorial(input1[1]), delta: 0.0000000001m);
            //Assert.AreEqual(1m, root.Faktorial(input1[2]), delta: 0.0000000001m);
            //Assert.AreEqual(1m, root.Faktorial(input1[3]), delta: 0.0000000001m);
            //Assert.AreEqual(1m, root.Faktorial(input1[4]), delta: 0.0000000001m);
            //Assert.AreEqual(1m, root.Faktorial(input1[5]), delta: 0.0000000001m);

        }
    }
}
