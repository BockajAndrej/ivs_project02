using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestCalculator
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int actual = CalculatorApp.Calculator.Divide(1, 2);

            Assert.AreEqual(1, actual);
        }
    }
}
