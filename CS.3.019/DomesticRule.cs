using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS._3._019
{
    public class DomesticRule : IBillingRule
    {
        private const double FixedFee = 50.0;
        private const double RatePerUnit = 6.0;
        public double Compute(int units) => units * RatePerUnit + FixedFee; 
    }
}
