using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydrometeorologicalStation
{
    internal struct Temperature
    {
        public readonly DateTime dateTime;
        double celsius;
        double fahrenheit;
        double kelvin;

        public Temperature(DateTime dateTime, double celsius)
        {
            this.dateTime = dateTime;
            this.celsius = celsius;
            fahrenheit = celsius * (9 / 5) + 32;
            kelvin = celsius + 273.15;
        }

        public string GetTemperature()
        {
            return $"For date {dateTime.ToShortDateString()} temperature for Celsius been {celsius}, " +
                   $"for Fahrenheit - {fahrenheit}, for Kelvin - {kelvin}";
        }
    }
}
