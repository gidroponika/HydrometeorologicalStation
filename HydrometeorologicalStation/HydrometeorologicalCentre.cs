using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydrometeorologicalStation
{
    internal class HydrometeorologicalCentre
    {
        Temperature[] temperatures;

        public HydrometeorologicalCentre(params Temperature[] temp)
        {
            temperatures = temp;
        }

        public Temperature this[DateTime dateTime]
        {
            get
            {
                return GetTemperatureByDate(dateTime);
            }
        }

        public Temperature[] this[DateTime from, DateTime to]
        {
            get
            {
                return GetTemperatureByPeriod(from, to);
            }
        }

        Temperature GetTemperatureByDate(DateTime dateTime)
        {
            foreach (var temperature in temperatures)
            {
                if (string.Compare(temperature.dateTime.ToShortDateString(), dateTime.ToShortDateString()) == 0)
                {
                    return temperature;
                }
            }
            Console.WriteLine("No data at this time");
            return new Temperature();
        }

        Temperature[] GetTemperatureByPeriod(DateTime from, DateTime to)
        {
            TimeSpan ts = to - from;
            Temperature[] period = new Temperature[ts.Days + 1];
            int index = default;

            for (int i = 0; i < period.Length; i++)
            {
                if (temperatures[i].dateTime.Equals(from))
                {
                    index = i;
                    break;
                }
            }

            for (int i = 0; i < period.Length; i++)
            {
                period[i] = temperatures[index + i];
            }
            return period;
        }
    }
}
