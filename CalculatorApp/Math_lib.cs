using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp
{
    public class NegativeFactorialException : Exception
    {
        public NegativeFactorialException(string message) : base(message) { }
    }
    public class Math_lib
    {
        public decimal Count(decimal input1, decimal input2)
        {
            throw new NotImplementedException();
        }
        public decimal Substraction(decimal input1, decimal input2)
        {
            throw new NotImplementedException();
        }
        public decimal Multiplication(decimal v1, decimal v2)
        {
            throw new NotImplementedException();
        }

        public decimal Division(decimal v1, decimal v2)
        {
            throw new NotImplementedException();
        }

        public decimal Faktorial(decimal v1)
        {
            throw new NotImplementedException();
        }
    }
}
