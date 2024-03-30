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
        public decimal Count(decimal v1, decimal v2)
        {
            //checked add time for calcula
            checked // overflow check, throws overflowexception
            {
                return v1 + v2;
            }
        }
        public decimal Substraction(decimal v1, decimal v2)
        {
            checked // overflow check, throws overflowexception
            {
                return v1 - v2;
            }
        }
        public decimal Multiplication(decimal v1, decimal v2)
        {
            checked // overflow check, throws overflowexception
            {
                return v1 * v2;
            }
        }

        public decimal Division(decimal v1, decimal v2)
        {
            if(v2 != 0)
            {
                return v1 / v2;
            }
            else throw new DivideByZeroException("Cannot divide by zero");
        }

        public decimal Modulo(decimal v1,decimal v2)
        {
            if (v2 != 0)
            {
                return v1 % v2;
            }
            else throw new DivideByZeroException("Cannot divide by zero");
        }
        public decimal Faktorial(decimal v1)
        {
            if (v1 == 0)
            {
                return 1;
            }
            else if (v1 < 0)
            {
                throw new NegativeFactorialException("Factorial is not defined for negative numbers");
            }
            else // v1 is positive
            {
                decimal result = 1;
                for (decimal i = 2; i <= v1; i++)
                {
                    result *= i;
                }
                return result;
            }
        }
    }
}
