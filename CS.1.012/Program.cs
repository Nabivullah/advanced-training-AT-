namespace CS._1._012
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create three tariffs using different constructors.
            Tariff tariff1 = new Tariff("Domestic");
            Tariff tariff2 = new Tariff("Commercial", 8.0);
            Tariff tariff3 = new Tariff("Agricultural", -10.0, 100.0);

            //For units=120, print computed bill for each.
            int units = 120;
            Console.WriteLine($"{tariff1.Name} : {tariff1.ComputeBill(units)}");
            Console.WriteLine($"{tariff2.Name} : {tariff2.ComputeBill(units)}");
            Console.WriteLine($"{tariff3.Name} : {tariff3.ComputeBill(units)}");
        }
    }
}
