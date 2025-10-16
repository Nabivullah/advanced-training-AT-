using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using static System.Net.Mime.MediaTypeNames;
using static System.Reflection.Metadata.BlobBuilder;

namespace CS._3._005
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Simulate a 30 - day month for one meter:
            int[] pattern = new int[10];
            int[] month = new int[30];

            for(int i = 0; i < pattern.Length; i++)
            {
                Console.Write($"Enter day {i + 1} units: ");
                pattern[i] = int.Parse(Console.ReadLine());
            }

            for(int i = 0; i < month.Length; i++)
            {
                month[i] = pattern[i % 10];
            }

            string Category;
            int Units=0, Outages=0;
            double Energy, Fixed, Rebate, Total;

            Console.Write("Enter Category (DOMESTIC/COMMERCIAL): ");
            Category = Console.ReadLine().ToUpper();
            for(int i = 0; i < month.Length; i++)
            {
                Units += month[i];
                if(month[i] == 0)
                {
                    Outages++;
                }
            }

            //Use a switch on category string.
            switch(Category)
            {
                case "DOMESTIC":
                    Fixed = 50;
                    break;
                case "COMMERCIAL":
                    Fixed = 150;
                    break;
                default:
                    Console.WriteLine("Invalid Category");
                    return;
            }
            //Compute energy charge using slabs:
            if(Units <= 100)
            {
                Energy = Units * 4.0;
            }
            else if(Units <= 300)
            {
                Energy = (100 * 4.0) + ((Units - 100) * 6.0);
            }
            else
            {
                Energy = (100 * 4.0) + (200 * 6.0) + ((Units - 300) * 8.5);
            }
            //If outageDays == 0, apply 2 % rebate on(energy + fixed) ; otherwise no rebate.
            if(Outages == 0)
            {
                Rebate = 0.02 * (Energy + Fixed);
            }
            else
            {
                Rebate = 0;
            }
            Total = Convert.ToDouble(Energy + Fixed - Rebate);
            //Print a tidy invoice line with the breakdown.
            Console.WriteLine("\n--- Invoice ---");
            Console.WriteLine($"Category: {Category} | Units: {Units} | Energy: Rs.{Energy} | Fixed: Rs.{Fixed} | Rebate: Rs.{Rebate} | Total: Rs.{Total} | Outages: {Outages} ");

        }
    }
}
