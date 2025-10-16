using System;

namespace CS._3._004
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // For 3 meters, each with 7 daily kWh entries:
            int[][] meters = new int[3][];
            string[] ids = { "A-1001", "B-2001", "C-3001" };

            // Variables for overall highest day
            int highestDayValue = 0;
            int highestDayOfMeter = -1;
            string highestDayMeterId = string.Empty;

            // Arrays to store results for each meter
            double[] meterTotals = new double[3];
            double[] meterAvgs = new double[3];
            bool[] peakAlerts = new bool[3];
            bool[] sustainedOutages = new bool[3];

            for (int i = 0; i < meters.Length; i++)
            {
                // Initializing the inner array for each meter
                meters[i] = new int[7];
                double total = 0;
                bool hasPeakAlert = false;
                bool hasSustainedOutage = false;
                int highestDayForThisMeter = 0;
                int highestDayIndexForThisMeter = -1;

                Console.WriteLine($"Enter 7 daily kWh entries for Meter {ids[i]}:");

                for (int j = 0; j < meters[i].Length; j++)
                {
                     
                    Console.Write($"Day {j + 1}: ");
                    int reading = Convert.ToInt16(Console.ReadLine());
                 
                    meters[i][j] = reading;
                    total += meters[i][j];

                    // Tracking highest day for this meter
                    if (meters[i][j] > highestDayForThisMeter)
                    {
                        highestDayForThisMeter = meters[i][j];
                        highestDayIndexForThisMeter = j + 1;
                    }

                    // Checking for peak alert (> 8 kWh)
                    if (meters[i][j] > 8)
                    {
                        hasPeakAlert = true;
                    }

                    // Checking for sustained outage (two consecutive zero-days)
                    if (j > 0 && meters[i][j] == 0 && meters[i][j - 1] == 0)
                    {
                        hasSustainedOutage = true;
                    }
                }

                // Checking and updateing overall highest day
                if (highestDayForThisMeter > highestDayValue)
                {
                    highestDayValue = highestDayForThisMeter;
                    highestDayMeterId = ids[i];
                    highestDayOfMeter = highestDayIndexForThisMeter;
                }

                // Storing calculations for each meter
                meterTotals[i] = total;
                meterAvgs[i] = total / meters[i].Length;
                peakAlerts[i] = hasPeakAlert;
                sustainedOutages[i] = hasSustainedOutage;
            }

            Console.WriteLine("\n--- Meter Report ---");
            for (int i = 0; i < ids.Length; i++)
            {
                string peakAlertText = peakAlerts[i] ? "Yes" : "No";
                string sustainedOutageText = sustainedOutages[i] ? "Yes" : "No";

                Console.WriteLine($"Meter {ids[i]}: Total = {meterTotals[i]} kWh, Average = {meterAvgs[i]:F2} kWh/day, Peak Alert = {peakAlertText}, Sustained Outage = {sustainedOutageText}");
            }

            Console.WriteLine("\n--- Summary Report ---");
            Console.WriteLine($"Highest Day: {highestDayValue} kWh | Meter: {highestDayMeterId} | Day: {highestDayOfMeter}");
        }
    }
}
