using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS._3._017
{
    class SustainedOutageRule : AlarmRule
    {
        //// trigger if consecutive zero hours >= N
        //private readonly int _minConsecutive;
        //public SustainedOutageRule(int min) : base("SustainedOutage"){
        //    //here we are calling the base class constructor and passing the
        //    //name "SustainedOutage" so that the base class can initialize the Name
        //    _minConsecutive = min;
        //}
        //public override bool IsTriggered(LoadProfileDay day) { /* scan */ }
        private readonly int _minConsecutive;

        public SustainedOutageRule(int min) : base("SustainedOutage") => _minConsecutive = min;

        public override bool IsTriggered(LoadProfileDay day) {
            int consecutiveZeros = 0;
            foreach (var hour in day.HourlyLoad)
            {
                if (hour == 0)
                {
                    consecutiveZeros++;
                    if (consecutiveZeros >= _minConsecutive) // we count the number of zeros and if that
                                                             // is greater than the minimum count then we get a true else false
                    {
                        return true;
                    }
                }
                else
                {
                    consecutiveZeros = 0;
                }
            }
            return false;
        }

       
    }
}
