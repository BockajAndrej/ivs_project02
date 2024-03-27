using CalculatorApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestCalculator
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_Count()
        {
            // Create an instance to test:
            Math_lib rooter = new Math_lib();

            // Define a test input and output value:
            double expectedResult = 4;
            double input = 2;

            // Run the method under test:
            double actualResult = rooter.Count(input, input);

            // Verify the result:
            Assert.AreEqual(expectedResult, actualResult, delta: 0);
        }
        [TestMethod]
        public void Test_subtraction()
        {
            Math_lib rooter = new Math_lib();

            double expectedResult = 0;
            double input = 2;

            double actualResult = rooter.Substraction(input, input);

            Assert.AreEqual(expectedResult, actualResult, delta: 0);
        }
    }
}
