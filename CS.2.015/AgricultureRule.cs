using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS._2._015
{
    internal class AgricultureRule: IBillingRule
    {
        /* 3.0/unit + 0 fixed */
        public string category = "Agriculture";
        public double Compute(int units)
        {
            return 3 * units;
        }
        public string Category()
        {
            return "Agriculture";
        }
    }
}
