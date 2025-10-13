using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS._3._019
{
    public class CommercialRule : IBillingRule
    {
        private const double FixedFee = 150.0;
        private const double RatePerUnit = 8.5;
        public double Compute(int units) => units * RatePerUnit + FixedFee; 
    }
}
