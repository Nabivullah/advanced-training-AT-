using System.Runtime.Intrinsics.X86;

namespace CS._2._003
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //You’re given 7 CSV - like lines: yyyy - MM - dd,kWh,status where status is OK / OUTAGE / TAMPER.Compute:
            string[] lines = new string[7];
            string date;
            double kwh = 0;
            string status;
            int outageCount = 0;
            int tamperCount = 0;
            double okSum = 0;
            int okCount = 0;
            double okAvg = 0;

            Console.WriteLine("Enter 7 lines of data (yyyy-MM-dd,kWh,status):");


            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = Console.ReadLine();  //input
            }
            //For each line: Split(','), double.Parse, if/else if.
            foreach (string line in lines)
            {
                //Split(','), double.Parse, if/else if
                string[] data = line.Split(',');
                date = data[0];
                kwh = Double.Parse(data[1]);
                status = data[2].Trim().ToUpper();
                if (status == "OK")
                {
                    okSum += kwh;  //Sum of kWh where status == OK
                    okCount++;
                }
                else if (status == "OUTAGE")
                {
                    outageCount++; //Count of OUTAGE days

                }
                else
                {
                    tamperCount++; //Count of TAMPER days
                }
            }

            okAvg = okSum / okCount;  //Average kWh across only OK days


            Console.WriteLine($"OK: {okSum} kWh(avg {okAvg}) | OUTAGE: {outageCount} | TAMPER: {tamperCount}");




        }
    }
}


