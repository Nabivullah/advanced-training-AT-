namespace ADVTraining_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Instantiate two meters, set properties via object initializer.
            meter meter1 = new meter("12345", "Home", DateTime.Now,1000);
            meter meter2 = new meter( "67890", "Office",DateTime.Now,2000);
            
            //Call AddReading with valid and invalid deltas.
            meter1.AddReading(150);
            meter1.AddReading(-50); // Invalid, should be ignored

            meter2.AddReading(300);
            meter2.AddReading(0); // Invalid, should be ignored
            //Print summaries to console.
            Console.WriteLine(meter1.Summary());
            Console.WriteLine(meter2.Summary());



        }
    }
}
