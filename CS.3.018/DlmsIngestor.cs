using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS._3._018
{
    public class DlmsIngestor : IDataIngestor
    {
        //emits count hourly tuples (ts, kwh=1..5). 
        private DateTime _lastReadTime = new DateTime(2025, 10, 6, 9, 0, 0);
        private int _kwhCounter = 0;

        public string Name => "Dlms";

        public IEnumerable<(DateTime ts, int kwh)> ReadBatch(int count)
        {
            for (int i = 0; i < count; i++)
            {
                _lastReadTime = _lastReadTime.AddHours(1);
                _kwhCounter = (_kwhCounter % 5) + 1;
                yield return (_lastReadTime, _kwhCounter); 
            }
        }
    }
}
