using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS._2._014
{
    public class ModemGateway : IReadable
    {
        //ModemGateway : IReadable (returns a random 0--2 kWh representing backfill).

        private Random _rand = new Random();
        private int _lastReading = 0;
        public int ReadKwh()
        {
            int delta = _rand.Next(0, 3); // Returns a random integer from 0 to 2
            _lastReading += delta;
            return delta;
        }
        public string SourceId
        {
            get { return "AP-0001"; }
        }
    }
}
