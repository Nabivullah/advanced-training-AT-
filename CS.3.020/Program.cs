namespace CS._3._020
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a mixed list of 8 events across 3 types.
            Console.WriteLine(
                "Creating a mixed list of 8 events across 3 types (OutageEvent, TamperEvent, VoltageEvent)...");
            List<Event> events = new List<Event>
                {
                new OutageEvent(DateTime.Now.AddMinutes(-30), "AP-0007", 15),
                new TamperEvent(DateTime.Now.AddMinutes(-20), "AP-0003", "MISMATCH"),
                new VoltageEvent(DateTime.Now.AddMinutes(-10), "AP-0010", 230.5),
                new OutageEvent(DateTime.Now.AddMinutes(-25), "AP-0001", 30),
                new TamperEvent(DateTime.Now.AddMinutes(-5), "AP-0013", "ERROR"),
                new VoltageEvent(DateTime.Now.AddMinutes(-15), "AP-0027", 220.0),
                new OutageEvent(DateTime.Now.AddMinutes(-40), "AP-0006", 45),
                new VoltageEvent(DateTime.Now.AddMinutes(0), "AP-0002", 260.0)
            };
            //Process and print the top 3 by severity/ recency.
            Console.WriteLine("Processing and printing the top 3 by severity/ recency...");
            EventProcessor.PrintTopSevere(events, 3);
            Console.WriteLine(
                "Done. Press any key to exit.");
            Console.ReadKey();
        }
    }
}
