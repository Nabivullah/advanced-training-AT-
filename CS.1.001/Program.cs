using System.ComponentModel.Design;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CS._1._001
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Prompts for meterSerial(string), prevReading(int), currReading(int).

            Console.WriteLine("Enter Meter Serial Number:");
            string meterSerial = Console.ReadLine();

            int prevReading=0, currReading=0;
            double energyCharge = 0, tax = 0, total = 0;

            Console.WriteLine("Enter Previous Reading: ");
            int temp1= Convert.ToInt32(Console.ReadLine());
            if ( temp1 > 0)
            {
                prevReading = temp1;
            }
            else
            {
                Console.WriteLine("Enter Valid prevReading");
            }


            Console.WriteLine("Enter Current Reading: ");
            int temp2 = Convert.ToInt32(Console.ReadLine());
            if (temp2 > 0)
            {
                currReading = temp2;
            }
            else
            {
                Console.WriteLine("Enter Valid currReading");
            }


            //Computes units = currReading - prevReading.
            int units = currReading - prevReading;

            //If units ≤ 0, print an error.
            if (units <= 0) 
                Console.WriteLine("Please Enter valid Values for Readings and try again");
            
            //Else compute energyCharge = units * 6.5 and a tax = 5 % and total = energyCharge + tax.
            else {
                    energyCharge = units * 6.5;
                    tax = energyCharge * 0.05;
                    total = energyCharge + tax;
            }

            //Print a one - line bill summary.
            if (units > 500)
            {
                Console.WriteLine("High Usage Alert");
            }
            else {
             Console.WriteLine($"Meter {meterSerial} | Units: {units} | Energy: {energyCharge} | Tax(5%): {tax} | Total: {total}");
            }


        }
    }
}
