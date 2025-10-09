using System.Security.Cryptography.X509Certificates;

namespace CS._2._014
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Put both in List<IReadable> and poll 5 times (loop).

            List<IReadable> meters = new List<IReadable>();
            meters.Add(new ModemGateway() { });
            meters.Add(new dlmsMeter() { });
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Poll {i + 1}");
                foreach (var meter in meters)
                {
                    int kwh = meter.ReadKwh();
                    Console.WriteLine($"{meter.SourceId} -> {kwh} kWh");
                }
                Console.WriteLine();
            }

        }
    }
}
