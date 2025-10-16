using System.ComponentModel;
using System.Diagnostics.Metrics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CS._3._009
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Simulate meter status logs for a week:Each day record:Status = "OK", "OUTAGE", "TAMPER", "LOW_VOLT".
            string[] status= new string[7];
            
            for(int i=0;i<status.Length;i++)   //Writing loop to generate random status for each day.
            {
                Random rand = new Random();
                int num = rand.Next(0, 4);
                switch (num)
                {
                    case 0:
                        status[i] = "OK";
                        break;
                    case 1:
                        status[i] = "OUTAGE";
                        break;
                    case 2:
                        status[i] = "TAMPER";
                        break;
                    case 3:
                        status[i] = "LOW_VOLT";
                        break;
                }
            }
            int outageCount = 0;
            int tamperCount = 0;
            int lowVoltCount = 0;
            int okCount = 0;

            for(int i=0;i<status.Length;i++)      //Count how many times each event occurs.
            {
                if(status[i] == "OUTAGE")
                {
                    outageCount++;
                }
                else if(status[i] == "TAMPER")
                {
                    tamperCount++;
                }
                else if(status[i] == "LOW_VOLT")
                {
                    lowVoltCount++;
                }
                else if(status[i] == "OK")
                {
                    okCount++;
                }
            }

            if(outageCount > 2 || tamperCount > 1) //If outage count > 2 OR tamper count > 1 → print “Maintenance required”.
            {
                Console.WriteLine($"OK: {okCount} | OUTAGE: {outageCount} | TAMPER: {tamperCount} | LOW_VOLT: {lowVoltCount} | Maintenance required");
            }
            else   //Else print “Meter healthy”.
            {
                Console.WriteLine($"OK: {okCount} | OUTAGE: {outageCount} | TAMPER: {tamperCount} | LOW_VOLT: {lowVoltCount} | Meter healthy");
            }
            

            

            

            
        }
    }
}
