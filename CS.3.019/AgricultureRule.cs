using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS._3._019
{
    public class AgricultureRule : IBillingRule
    {
        private const double FixedFee = 0.0;
        private const double RatePerUnit = 3.0;
        public double Compute(int units) => units * RatePerUnit + FixedFee; // Agriculture has no fixed fee
    }
}
