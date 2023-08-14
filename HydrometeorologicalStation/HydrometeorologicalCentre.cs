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
            temperatures = temp ;
            //Array.Copy(temp,0,temperatures,0,temp.Length-1);
            //Array.Copy(temp, temperatures, temp.Length-1);
        }

        public Temperature this[DateTime dateTime]
        {
            get
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
        }

        //public void Add(Temperature temp)
        //{
        //    for (int i = 0; i < temperatures.Length; i++)
        //    {
        //        Nullable<Temperature> n = temperatures[i];
        //        if (!n.HasValue)
        //        {
        //            Console.WriteLine(i);
        //            temperatures[i] = temp;
        //            return;
        //        }
        //        if (temperatures[i].isEmpty)
        //        {
        //            temperatures[i] = temp;
        //            return;
        //        }
        //    }
        //}

        public Temperature[] this[DateTime from, DateTime to]
        {
            get
            {
                return GetTemperatureByPeriod(from, to);
                //TimeSpan ts = to - from;
                //Temperature[] period = new Temperature[ts.Days];
                //int index=default;

                //for (int i = 0; i < period.Length; i++)
                //{
                //    if (temperatures[i].dateTime.Equals(from))
                //    {
                //        index= i;
                //        break;
                //    }
                //}

                //for (int i = 0; i < period.Length; i++)
                //{
                //    period[i] = temperatures[index + i];
                //}
                //return period;
            }
        }

        //public Temperature GetTemperatureByDate(DateTime dateTime)
        //{
        //    foreach (var temperature in temperatures)
        //    {
        //        if (string.Compare(temperature.dateTime.ToShortDateString(), dateTime.ToShortDateString()) == 0)
        //        {
        //            return temperature;
        //        }
        //    }
        //    Console.WriteLine("No data at this time");
        //    return new Temperature();
        //}

        public Temperature[] GetTemperatureByPeriod(DateTime from,DateTime to)
        {
            TimeSpan ts = from - to;
            Temperature[] period = new Temperature[ts.Days];
            int index=Array.IndexOf(temperatures, from);

            if(index+ ts.Days < temperatures.Length)
            {
                for (int i = 0; i < period.Length; i++)
                {
                    period[i] = temperatures[index + i];
                }
                //return period;
            }
            else
            {
                int length = index + ts.Days - temperatures.Length;
                length = ts.Days - length;
                for(int i = 0; i < length; i++)
                {
                    period[i] = temperatures[index + i];
                }
            }

            return period;
        }
    }
}
