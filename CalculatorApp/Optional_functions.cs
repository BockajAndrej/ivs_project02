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
            if (Math.Abs(v1) > Decimal.MaxValue)
            {
                throw new OverflowException("Input value is too large to handle");
            }
            if (v1 < 0)
            {
                throw new NegativeNumberException("Input value is negative.");
            }
            switch (v2)
            {
                case "sec":
                    switch (v3)
                    {
                        case "sec":
                            return v1;
                        case "min":
                            return (v1 / 60);
                        case "hour":
                            return (v1 / 3600);
                        case "days":
                            return (v1 / 86400);
                        case "weeks":
                            return (v1 / 604800);
                        case "months":
                            return (v1 / (decimal)2629743.83);
                        case "years":
                            return (v1 / 31556926);
                        default:
                            break;
                    }
                    break;
                case "min":
                    switch (v3)
                    {
                        case "sec":
                            return (v1 * 60);
                        case "min":
                            return v1;
                        case "hour":
                            return (v1 / 60);
                        case "days":
                            return (v1 / 1440);
                        case "weeks":
                            return (v1 / 10080);
                        case "months":
                            return (v1 / (decimal)43829.0639);
                        case "years":
                            return (v1 / (decimal)525948.766);
                        default:
                            break;
                    }
                    break;
                case "hour":
                    switch (v3)
                    {
                        case "sec":
                            return (v1 * 3600);
                        case "min":
                            return (v1 * 60);
                        case "hour":
                            return v1;
                        case "days":
                            return (v1 / 24);
                        case "weeks":
                            return (v1 / 168);
                        case "months":
                            return (v1 / (decimal)730.484398);
                        case "years":
                            return (v1 / (decimal)8765.81277);
                        default:
                            break;
                    }
                    break;
                case "days":
                    switch (v3)
                    {
                        case "sec":
                            return (v1 * 86400);
                        case "min":
                            return (v1 * 1440);
                        case "hour":
                            return (v1 * 24);
                        case "days":
                            return v1;
                        case "weeks":
                            return (v1 / 7);
                        case "months":
                            return (v1 / (decimal)30.4368499);
                        case "years":
                            return (v1 / (decimal)365.242199);
                        default:
                            break;
                    }
                    break;
                case "weeks":
                    switch (v3)
                    {
                        case "sec":
                            return (v1 * 604800);
                        case "min":
                            return (v1 * 10080);
                        case "hour":
                            return (v1 * 168);
                        case "days":
                            return (v1 * 7);
                        case "weeks":
                            return v1;
                        case "months":
                            return (v1 / (decimal)4.34812141);
                        case "years":
                            return (v1 / (decimal)52.177457);
                        default:
                            break;
                    }
                    break;
                case "months":
                    switch (v3)
                    {
                        case "sec":
                            return (v1 * (decimal)2629743.83);
                        case "min":
                            return (v1 * 438290639);
                        case "hour":
                            return (v1 * (decimal)730.484398);
                        case "days":
                            return (v1 * (decimal)30.4368499);
                        case "weeks":
                            return (v1 * (decimal)4.34812141);
                        case "months":
                            return v1;
                        case "years":
                            return (v1 / 12);
                        default:
                            break;
                    }
                    break;
                case "years":
                    switch (v3)
                    {
                        case "sec":
                            return (v1 * 31556926);
                        case "min":
                            return (v1 * (decimal)525948.766);
                        case "hour":
                            return (v1 * (decimal)8765.81277);
                        case "days":
                            return (v1 * (decimal)365.242199);
                        case "weeks":
                            return (v1 * (decimal)52.177457);
                        case "months":
                            return (v1 * 12);
                        case "years":
                            return v1;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
            throw new UndefinedUnitException("Undefined unit exception.");
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
            if (Math.Abs(v1) > Decimal.MaxValue)
            {
                throw new OverflowException("Input value is too large to handle");
            }
            switch (v2)
            {
                case "mg":
                    switch (v3)
                    {
                        case "mg":
                            return v1;
                        case "g":
                            return (v1 / 1000);
                        case "dag":
                            return (v1 / 10000);
                        case "kg":
                            return (v1 / 1000000);
                        case "t":
                            return (v1 / 1000000000);
                        case "lb":
                            return (v1 * (decimal)0.00000220462262);
                        case "oz":
                            return (v1 * (decimal)0.00003527396195);
                        default:
                            break;
                    }
                    break;
                case "g":
                    switch (v3)
                    {
                        case "mg":
                            return (v1 * 1000);
                        case "g":
                            return v1;
                        case "dag":
                            return (v1 / 10);
                        case "kg":
                            return (v1 / 1000);
                        case "t":
                            return (v1 / 1000000);
                        case "lb":
                            return (v1 * (decimal)0.00220462262);
                        case "oz":
                            return (v1 * (decimal)0.03527396195);
                        default:
                            break;
                    }
                    break;
                case "dag":
                    switch (v3)
                    {
                        case "mg":
                            return (v1 * 10000);
                        case "g":
                            return (v1 * 10);
                        case "dag":
                            return v1;
                        case "kg":
                            return (v1 / 100);
                        case "t":
                            return (v1 / 100000);
                        case "lb":
                            return (v1 * (decimal)0.0220462262);
                        case "oz":
                            return (v1 * (decimal)0.352739619);
                        default:
                            break;
                    }
                    break;
                case "kg":
                    switch (v3)
                    {
                        case "mg":
                            return (v1 * 1000000);
                        case "g":
                            return (v1 * 1000);
                        case "dag":
                            return (v1 * 100);
                        case "kg":
                            return v1;
                        case "t":
                            return (v1 / 1000);
                        case "lb":
                            return (v1 * (decimal)2.20462262);
                        case "oz":
                            return (v1 * (decimal)35.2739619);
                        default:
                            break;
                    }
                    break;
                case "t":
                    switch (v3)
                    {
                        case "mg":
                            return (v1 * 1000000000);
                        case "g":
                            return (v1 * 1000000);
                        case "dag":
                            return (v1 * 100000);
                        case "kg":
                            return (v1 * 1000);
                        case "t":
                            return v1;
                        case "lb":
                            return (v1 * (decimal)2204.62262);
                        case "oz":
                            return (v1 * (decimal)35273.9619);
                        default:
                            break;
                    }
                    break;
                case "lb":
                    switch (v3)
                    {
                        case "mg":
                            return (v1 * (decimal)453592.37);
                        case "g":
                            return (v1 * (decimal)453.59237);
                        case "dag":
                            return (v1 * (decimal)45.359237);
                        case "kg":
                            return (v1 * (decimal)0.45359237);
                        case "t":
                            return (v1 * (decimal)0.00045359237);
                        case "lb":
                            return v1;
                        case "oz":
                            return (v1 * 16);
                        default:
                            break;
                    }
                    break;
                case "oz":
                    switch (v3)
                    {
                        case "mg":
                            return (v1 * (decimal)28349.5231);
                        case "g":
                            return (v1 * (decimal)28.3495231);
                        case "dag":
                            return (v1 * (decimal)2.83495231);
                        case "kg":
                            return (v1 * (decimal)0.0283495231);
                        case "t":
                            return (v1 * (decimal)0.0000283495231);
                        case "lb":
                            return (v1 * (decimal)0.0625);
                        case "oz":
                            return v1;
                        default:
                            break;
                    }
                    break;
                default:
                    break;

            }
            throw new UndefinedUnitException("Undefined unit exception.");
        }
    }
}
