using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS._2._016
{
    internal class LoadProfileDay
    {
        public DateTime Date { get; }
        public int[] HourlyKwh { get; } // length 24
        bool flag = true;
        public LoadProfileDay(DateTime date, int[] hourly)
        {
            // clone array; validate length == 24; values >= 0
            if (hourly == null || hourly.Length != 24)
            {
                throw new ArgumentException("Hourly readings must be a non-null array of 24 integers.", nameof(hourly));// throws an error
            }
            foreach (int kwh in hourly)
            {
                if (kwh < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(hourly), "Hourly readings cannot contain negative values."); //throws an error
                }
            }
            this.Date = date;
            this.HourlyKwh = (int[])hourly.Clone();

        }
        public int Total() // method to get the total kwh used
        {
            return this.HourlyKwh.Sum();
            
        }

        public int PeakHour() // method to find the hour in which there was peak energy usage 
        {
            int max = this.HourlyKwh[0];
            int idx = 0;
            for(int i=0;i<this.HourlyKwh.Length;i++)
            {
                if (this.HourlyKwh[i] > max) {  max = this.HourlyKwh[i]; idx = i; }
            }
            return idx;
        }
    }
}
