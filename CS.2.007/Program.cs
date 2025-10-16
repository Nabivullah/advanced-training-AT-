using System.Runtime.Intrinsics.X86;

namespace CS._2._007
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Given a meterCategory("DOMESTIC", "COMMERCIAL", "AGRICULTURE"):
            string meterCategory;
            Console.WriteLine("Enter meter category (DOMESTIC, COMMERCIAL, AGRICULTURE): ");
            meterCategory = Console.ReadLine().ToUpper();
            int units;
            Console.WriteLine("Enter number of units consumed: ");
            units = Convert.ToInt32(Console.ReadLine());
            double rate = 0.0;
            double totalBill = 0.0;
            switch (meterCategory) //Use switch to assign rate
            {
                case "DOMESTIC":
                    rate = 6.0;
                    totalBill=rate*units;
                    break;
                case "COMMERCIAL":
                    rate = 8.5;
                    totalBill = rate * units;
                    break;
                case "AGRICULTURE":
                    rate = 3.0;
                    totalBill = rate * units;
                    break;
                default:
                    Console.WriteLine("Invalid meter category.");
                    return;
            }
            Console.WriteLine($"Category: {meterCategory} | Rate: Rs.{rate} | Total Bill: Rs.{totalBill}");//Calculate total bill for given units.

        }
    }
}
