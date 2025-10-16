using System.Buffers.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CS._2._002
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Given 7 daily kWh values for a meter, compute:

            Console.WriteLine("Enter the daily kWh values for your meter");
            int[] daily = new int[7];
            int Total=0;
            double average=0;
            int maxUsage = 0;
            int Day = 1;
            int outageDays = 0;
            int min = int.MaxValue;
            int minday = 1;


            for (int i = 0; i < daily.Length; i++)
            {
                daily[i] = Convert.ToInt32(Console.ReadLine());
                Total+= daily[i];
                if (daily[i] == 0)
                {
                    outageDays++;//Number of outage days(value == 0)
                }
                if(daily[i]> maxUsage)
                {
                    maxUsage=daily[i];      //Day index(1 - based) of max usage
                    Day =i+1;
                }
                if (daily[i] < min) { 
                    min=daily[i];  
                    minday= i+1;  
                }
            }
            //Total, average
            average= Convert.ToDouble(Convert.ToDouble(Total)/(7.00));
            

            //Print all on one line.
            Console.WriteLine($"Total: {Total} kWh | Avg: {average} kWh | Max: {maxUsage} kWh (Day {Day}) | Outages: {outageDays} | Min: {min} kWh (Day {minday})");
        }
    }
}
