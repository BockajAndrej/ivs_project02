using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp
{
    public class Optional_functions
    {
        public class UndefinedUnitException : Exception
        {
            public UndefinedUnitException(string message) : base(message) { }
        }
        public class NegativeNumberException : Exception
        {
            public NegativeNumberException(string message) : base(message) { }
        }

        // Create an instance to Math functions:
        Math_lib root = new Math_lib();

        /// <summary>
        /// A function to calculate a plane angle
        /// </summary>
        /// <param name="v1">Value</param>
        /// <param name="v2">From</param>
        /// <param name="v3">To</param>
        /// <returns>Decimal value</returns>
        /// <exception cref="NotImplementedException"></exception>
        /// degrees(deg), rad
        public decimal Degrees(decimal v1, string v2, string v3)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// A function to calculate density
        /// </summary>
        /// <param name="v1">Value</param>
        /// <param name="v2">From</param>
        /// <param name="v3">To</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        /// kg/m3, g/m3, g/cm3, kg/cm3
        public decimal Density(decimal v1, string v2, string v3)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// A function to calculate amount of energy
        /// </summary>
        /// <param name="v1">Value</param>
        /// <param name="v2">From</param>
        /// <param name="v3">To</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        /// joule(J), kilojoule(kJ)
        public decimal Energy(decimal v1, string v2, string v3)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// A function to calculate length
        /// </summary>
        /// <param name="v1">Value</param>
        /// <param name="v2">From</param>
        /// <param name="v3">To</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        /// mm, cm, dm, m, km, miles, inch, yard
        public decimal Length(decimal v1, string v2, string v3)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// A funtion to calculate performance
        /// </summary>
        /// <param name="v1">Value</param>
        /// <param name="v2">From</param>
        /// <param name="v3">To</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        /// watt, kilowatt
        public decimal Performance(decimal v1, string v2, string v3)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// A function to calculate speed
        /// </summary>
        /// <param name="v1">Value</param>
        /// <param name="v2">From</param>
        /// <param name="v3">To</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        /// km/h, miles/h, m/s
        public decimal Speed(decimal v1, string v2, string v3)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// A function to calculate temperature
        /// </summary>
        /// <param name="v1">Value</param>
        /// <param name="v2">From</param>
        /// <param name="v3">To</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        /// celsius(C), fahrenheit(F), kelvin(K)
        public decimal Temp(decimal v1, string v2, string v3)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// A funtion to calculate time units
        /// </summary>
        /// <param name="v1">Value</param>
        /// <param name="v2">From</param>
        /// <param name="v3">To</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        /// sec, min, hour, days, weeks, months, years
        public decimal Time(decimal v1, string v2, string v3)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// A function to calculate weight
        /// </summary>
        /// <param name="v1">Value</param>
        /// <param name="v2">From</param>
        /// <param name="v3">To</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        /// mg, dag, g, kg, t, lb, oz
        public decimal Weight(decimal v1, string v2, string v3)
        {
            throw new NotImplementedException();
        }
    }
}
