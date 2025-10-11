using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS._3._017
{
    internal class LoadProfileDay //This class contains the initialization which is going to be used later in code
    {
        public DateTime Date { get; }
        public List<double> HourlyLoad { get; }

        public double Total => HourlyLoad.Sum();

        public LoadProfileDay(DateTime date, List<double> hourlyLoad)
        {
            Date = date;
            HourlyLoad = hourlyLoad;
        }
    }
}
