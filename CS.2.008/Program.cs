using System.Runtime.Intrinsics.X86;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CS._2._008
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Simulate 7 - day load readings in an array.
            double[] daily=new double[7] ;
            double Total=0, Avg=0;
            int PeakDays=0, Outages=0;
            for (int i=0 ; i<7 ; i++) {
                Console.Write($"Enter load for day {i + 1}: ");
                daily[i]=Convert.ToDouble(Console.ReadLine());
                Total += daily[i];
                if(daily[i]>6) {
                    PeakDays++;
                }
                if(daily[i]==0) {
                    Outages++;
                }
            }

            Avg=Total/7;
            Console.WriteLine($"Total: {Total} kWh | Avg: {Avg} kWh | Peak Days (>6): {PeakDays} | Outages: {Outages} ");



            //Compute total and average consumption.

            //Count how many days exceed 6 kWh(peak days).

            //Count outage days(0 kWh).
        }
    }
}
