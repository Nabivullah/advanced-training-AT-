using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS._3._019
{
    public interface IBillingRule
    {
        double Compute(int units);
    }
}
