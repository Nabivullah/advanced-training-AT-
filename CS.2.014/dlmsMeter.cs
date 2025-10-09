using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS._2._014
{
    public class dlmsMeter : IReadable
    {
        //DlmsMeter : IReadable (returns a random 1--10 kWh).

        private Random _rand = new Random();
        private int _lastReading = 0;
        public int ReadKwh()
        {
            int delta = _rand.Next(1, 11); // Returns a random integer from 1 to 10
            _lastReading += delta;
            return delta;
        }
        public string SourceId
        {
            get { return "GW-21"; }
        }


    }
}
