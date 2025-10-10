using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS._2._015
{
    internal class DomesticRule : IBillingRule
    {
        /* 6.0/unit + 50 fixed */

        public string category = "Domestic";
        public double Compute(int units)
        {
            return 50 + (6 * units);
        }
        public string Category()
        {
            return "Domestic";
        }
    }
}
