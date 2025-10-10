using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS._2._015
{
    internal class BillingEngine : IBillingRule
    {
        private readonly IBillingRule _rule;
        public BillingEngine(IBillingRule rule)
        {
            _rule = rule;
        }
        public double Compute(int units)
        {
            return _rule.Compute(units);
        }
        public string Category()
        {
            return _rule.Category();
        }
        public double GenerateBill(int units)
        {
            return Compute(units);
        }


    }
}
