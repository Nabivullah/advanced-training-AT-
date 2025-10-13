using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS._3._019
{
    public class BillingContext
    {
        public IBillingRule Rule { get; }
        public List<IRebate> Rebates { get; } = new();

        public BillingContext(IBillingRule rule) => Rule = rule;

        public double Finalize(int units, int outageDays)
        {
            double total = Rule.Compute(units);
            foreach (var r in Rebates)
            {
                total += r.Apply(total, outageDays); // Use units for HighUsageRebate
            }

            // Print intermediate values
            Console.WriteLine($"Subtotal: {Rule.Compute(units)}");
            Console.WriteLine($"Rebates: {string.Join(" | ", Rebates.Select(r => $"{r.Code}"))}");

            return total ;
        }
    }

}
