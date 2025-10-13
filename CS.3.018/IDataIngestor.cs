using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS._3._018
{
    public interface IDataIngestor
    {
        string Name { get; }
        IEnumerable<(DateTime ts, int kwh)> ReadBatch(int count);
    }
}
