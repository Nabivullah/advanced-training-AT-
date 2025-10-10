using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS._2._015
{
    internal class CommercialRule : IBillingRule
    {
        /* 8.5/unit + 150 fixed */
        //public string category = "Commercial";
        public double Compute(int units)
        {
            return 150 + (8.5 * units);
        }
        public string Category()
        {
            return  "Commercial";
        }
    }
}
