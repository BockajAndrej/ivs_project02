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
    /// <summary>
    /// Implementation of the mathematical library
    /// </summary>
    public class Math_lib
    {
        /// <summary>
        /// Counting two numbers
        /// </summary>
        /// <param name="v1"> - 1. number</param>
        /// <param name="v2"> - 2. number</param>
        /// <returns>Result of the operation</returns>
        public decimal Add(decimal v1, decimal v2)
        {
            /// Overflow check, throws overflowexception
            checked
            {
                return v1 + v2;
            }
        }
        /// <summary>
        /// Substraction two numbers
        /// </summary>
        /// <param name="v1"> - 1. number</param>
        /// <param name="v2"> - 2. number</param>
        /// <returns>Result of the operation</returns>
        public decimal Substraction(decimal v1, decimal v2)
        {
            /// Overflow check, throws overflowexception
            checked
            {
                return v1 - v2;
            }
        }
        /// <summary>
        /// Multiplication two numbers
        /// </summary>
        /// <param name="v1"> - 1. number</param>
        /// <param name="v2"> - 2. number</param>
        /// <returns>Result of the operation</returns>
        public decimal Multiplication(decimal v1, decimal v2)
        {
            /// Overflow check, throws overflowexception
            checked
            {
                return v1 * v2;
            }
        }
        /// <summary>
        /// Division two numbers
        /// </summary>
        /// <param name="v1"> - 1. number</param>
        /// <param name="v2"> - 2. number</param>
        /// <returns>Result of the operation</returns>
        /// <exception cref="DivideByZeroException"></exception>
        public decimal Division(decimal v1, decimal v2)
        {
            /// Overflow check, throws overflowexception
            checked
            {
                if (v2 != 0)
                {
                    return v1 / v2;
                }
                else throw new DivideByZeroException("Cannot divide by zero");
            }
        }
        /// <summary>
        /// Remainder after division
        /// </summary>
        /// <param name="v1"> - 1. number</param>
        /// <param name="v2"> - 2. number</param>
        /// <returns>Result of the operation</returns>
        /// <exception cref="DivideByZeroException"></exception>
        public decimal Modulo(decimal v1, decimal v2)
        {
            if (v2 != 0)
            {
                return v1 % v2;
            }
            else throw new DivideByZeroException("Cannot divide by zero");
        }
        /// <summary>
        /// Factorial calculation
        /// </summary>
        /// <param name="v1"> - just one number</param>
        /// <returns>Result of the operation</returns>
        /// <exception cref="NegativeFactorialException"></exception>
        /// <exception cref="OverflowException"></exception>
        public decimal Faktorial(decimal v1)
        {
            /// Overflow check, throws overflowexception
            checked
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
        }
        /// <summary>
        /// Exponentiation of a number 
        /// </summary>
        /// <param name="_base"> - base number</param>
        /// <param name="_exponent"> - exponent number</param>
        /// <returns></returns>
        /// <exception cref="NonNaturalExponentException"></exception>
        public decimal Exponentiation(decimal _base, decimal _exponent)
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
        /// <summary>
        /// Calculation of square roots
        /// </summary>
        /// <param name="v1"> - source number</param>
        /// <returns>Result of the operation</returns>
        /// <exception cref="NegativeRootException"></exception>
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
        /// <summary>
        /// Converting decimal number with periodical zeros on string  with specified numbers of digits agter the decimal point
        /// </summary>
        /// <param name="number"> - source number</param>
        /// <param name="decimalPlaces"> - specifies the number of digits after the decimal point</param>
        /// <returns>Converted decimal number to string</returns>
        public string FormatDecimal(decimal number, int decimalPlaces)
        {
            string formattedResult = number.ToString($"N{decimalPlaces}");

            // Check if there are trailing zeros after the decimal point
            if (formattedResult.Contains(","))
            {
                // Trim trailing zeros and the decimal point if all are zeros
                formattedResult = formattedResult.TrimEnd('0').TrimEnd(',');
            }

            return formattedResult;
        }
    }
}
