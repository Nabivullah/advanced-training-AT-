namespace CS._1._006
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Reads previous and current readings(in kWh).
            Console.Write("Enter previous reading (kWh): ");
            double previousReading = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter current reading (kWh): ");
            double currentReading = Convert.ToDouble(Console.ReadLine());
            double consumption = currentReading - previousReading; //Calculates the difference(consumption).
            if (consumption < 0)        //Checks:If consumption< 0 → Invalid.
            {
                Console.WriteLine("Invalid");
            }
            else if (consumption == 0)   //If consumption == 0 → Possible outage.
            {
                Console.WriteLine($"Net Consumption: {consumption} ,Possible outage detected");
            }
            else if (consumption > 500)  //If consumption > 500 → High consumption alert.
            {
                Console.WriteLine($"Net Consumption: {consumption} ,High consumption alert!");
            }
            else if(consumption > 100 && consumption < 500)
            {
                Console.WriteLine($"Net Consumption: {consumption} ,Consumption within normal range.");
            }

            

            

            

            

           
        }
    }
}
