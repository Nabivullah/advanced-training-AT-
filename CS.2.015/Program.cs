namespace CS._2._015
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //With units=120, compute bills using each rule instance.
            int units = 120;
            IBillingRule domesticRule = new DomesticRule();
            IBillingRule commercialRule = new CommercialRule();
            IBillingRule agricultureRule = new AgricultureRule();
            BillingEngine domesticBilling = new BillingEngine(domesticRule);
            BillingEngine commercialBilling = new BillingEngine(commercialRule);
            BillingEngine agricultureBilling = new BillingEngine(agricultureRule);
            //Print category -> amount.
            Console.WriteLine($"{domesticBilling.Category()} -> {domesticBilling.GenerateBill(units)}");
            Console.WriteLine($"{commercialBilling.Category()} -> {commercialBilling.GenerateBill(units)}");
            Console.WriteLine($"{agricultureBilling.Category()} -> {agricultureBilling.GenerateBill(units)}");

        }
    }
}
