using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADVTraining_2
{
    public class meter
    {
        string MeterSerial, Location;
        DateTime InstalledOn;
        int LastReadingKwh;

        public meter(string MeterSerial,string  Location , DateTime InstalledOn, int LastReadingKwh) {
            this.MeterSerial = MeterSerial;
            this.Location = Location;
            this.InstalledOn = InstalledOn;
            this.LastReadingKwh = LastReadingKwh;
        }
        //AddReading(int deltaKwh): adds to LastReadingKwh if deltaKwh > 0, else ignore.

        public void AddReading(int deltaKwh)
        {
            if (deltaKwh > 0)
            {
                LastReadingKwh += deltaKwh;
            }
        }
        //Summary(): returns "SERIAL Location: X | Reading: Y".
        public string Summary()
        {
            return $"AP-{MeterSerial} Location: {Location} | Reading: {LastReadingKwh}";
        }
    }
}
