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
    public class NonNaturalExponentException : Exception
    {
        public NonNaturalExponentException(string message) : base(message) { }
    }
    public class NegativeRootException : Exception
    {
        public NegativeRootException(string message) : base(message) { }
    }
    public class Math_lib
    {
        public decimal Add(decimal v1, decimal v2)
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
                    result = Multiplication(result, i);
                }
                return result;
            }
        }
        public decimal Exponentiation(decimal _base,decimal _exponent)
        {
            if (_exponent % 1 != 0) //can be only whole number without decimal point, cant change func parameter
            {
                throw new NonNaturalExponentException("Decimal point is not supported");
            }
            else if (_exponent == 0)
            {
                return 1;
            }
            else
            {
                decimal result = _base;
                for (int i = 1; i < _exponent; i++)
                {
                    result = Multiplication(result, _base);
                }
                return result;
            }

        }
        public decimal Abs(decimal v1)
        {
            return v1 < 0 ? -v1 : v1;
        }
        public decimal SquareRoot(decimal v1)
        {
            if (v1 == 0) return 0;
            if (v1 == 1) return 1;
            if (v1 < 0)
            {
                throw new NegativeRootException("Cannot find even-n root of a negative number");
            }
            decimal guess = v1;
            decimal tolerance = 0.000000000000000000001m;

            while (Abs(guess * guess - v1) > tolerance)
            {
                guess = (guess + v1 / guess) / 2;
            }
            return guess;
        }
        public string FormatDecimal(decimal number, int decimalPlaces)
        {
            // Convert decimal number with 0 in decimal places number without them
            if (number % 1 == 0)
            {
                return ((int)number).ToString();
            }
            else
            {
                return number.ToString($"N{decimalPlaces}"); //number of decimal places otherwise
            }
        }
    }
}
