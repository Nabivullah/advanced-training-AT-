using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS._3._018
{
    public class CsvIngestor : IDataIngestor
    {
        //emits from an in-memory string array of CSV lines.

        private readonly IEnumerator<string> _csvLinesEnumerator;

        public string Name => "Csv";

        public CsvIngestor(string[] csvLines)
        {
            _csvLinesEnumerator = csvLines.AsEnumerable().GetEnumerator();
        }

        public IEnumerable<(DateTime ts, int kwh)> ReadBatch(int count)
        {
            for (int i = 0; i < count && _csvLinesEnumerator.MoveNext(); i++)
            {
                string[] parts = _csvLinesEnumerator.Current.Split(',');
                if (parts.Length == 2 && DateTime.TryParse(parts[0], out var ts) && int.TryParse(parts[1], out var kwh))
                {
                    yield return (ts, kwh);
                }
            }
        }
    }
}
