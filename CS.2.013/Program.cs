namespace CS._2._013
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create Device[] with 1 meter + 1 gateway (polymorphic array).
            Device[] devices = new Device[2];
            devices[0] = new Meter { Id= "AP - 0001", Phases = 3 };
            devices[1] = new Gateway { Id = "GW-11", IpAddress = "10.0.5.21" };

            //Loop through array, calling Describe() on each.
            foreach (var device in devices)
            {
                Console.WriteLine(device.Describe());
            }
        }
    }

}
