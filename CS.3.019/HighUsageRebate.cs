using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS._3._019
{
    public class HighUsageRebate : IRebate
    {
        public string Code => "HIGH_USAGE";
        public double Apply(double currentTotal, int outageDays)
            => currentTotal > 500 ? -(currentTotal * 0.03) : 0; // 3% rebate if total exceeds $500
    }
}
