namespace CS._3._019
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Task: Rule = Commercial, units=620, outageDays=0. Apply both rebates.
            int units = 620;
            int outageDays = 0;
            var context = new BillingContext(new CommercialRule()); // Use CommercialRule
            context.Rebates.Add(new NoOutageRebate()); // Add both rebates
            context.Rebates.Add(new HighUsageRebate());

            

            double finalBill = context.Finalize(units, outageDays); // Compute final bill

            // Print final total
            Console.WriteLine($"Final:  {finalBill}");
        }
    }
}
