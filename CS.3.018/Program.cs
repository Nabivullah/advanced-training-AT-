namespace CS._3._018
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dlms = new DlmsIngestor();
            var dlmsWithOutages = new RandomOutageDecorator(dlms);

            Console.WriteLine($"Ingestor created: {dlmsWithOutages.Name}");
            Console.WriteLine("Calling ReadBatch(10):");

            // Call ReadBatch(10) and print 10 lines ts -> kwh.
            foreach (var dataPoint in dlmsWithOutages.ReadBatch(10))
            {
                Console.WriteLine($"[{dlmsWithOutages.Name}] {dataPoint.ts:yyyy-MM-dd HH:mm} -> {dataPoint.kwh}");
            }
        }
    }
}
