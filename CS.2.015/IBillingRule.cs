using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS._2._015
{
    internal interface IBillingRule
    {
        double Compute(int units);
        string Category();
    }
}
