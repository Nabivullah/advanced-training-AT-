using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS._3._018
{
    public abstract class IngestorDecorator : IDataIngestor
    {
        protected readonly IDataIngestor _ingestor;

        public IngestorDecorator(IDataIngestor ingestor)
        {
            _ingestor = ingestor;
        }

        public virtual string Name => _ingestor.Name;
        public abstract IEnumerable<(DateTime ts, int kwh)> ReadBatch(int count);
    }
}
