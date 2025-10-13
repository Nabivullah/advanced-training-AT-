using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS._3._019
{
    public class NoOutageRebate : IRebate
    {
        public string Code => "NO_OUTAGE";
        public double Apply(double currentTotal, int outageDays)
            => outageDays == 0 ? -(currentTotal * 0.02) : 0; // 2% rebate if no outages
    }
}
