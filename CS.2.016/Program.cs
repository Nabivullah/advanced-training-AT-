namespace CS._2._016
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Build a valid HourlyKwh array; instantiate a day.
            int[] demoHourlyKwh = {1,2,3,4,5,6,7,8,9,10,11,24,13,14,15,16,17,18,9,20,21,22,22,22};
            DateTime demoDate = DateTime.Now;

            LoadProfileDay NewLoadProfile = new LoadProfileDay (demoDate,demoHourlyKwh);

            //Print Date, Total, PeakHour.

            Console.WriteLine($"{demoDate} | Total: {NewLoadProfile.Total()} kWh | PeakHour: {NewLoadProfile.PeakHour()}");




        }
    }
}
