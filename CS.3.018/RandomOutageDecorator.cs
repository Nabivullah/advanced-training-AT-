using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS._3._018
{
    internal class RandomOutageDecorator : IngestorDecorator
    {
        //IDataIngestor → wraps any ingestor and randomly sets some kwh=0.
        private readonly Random _random = new Random();
        private readonly double _outageProbability;

        public override string Name => $"{_ingestor.Name}+Outage";

        public RandomOutageDecorator(IDataIngestor ingestor, double outageProbability = 0.2) : base(ingestor)
        {
            _outageProbability = outageProbability;
        }

        public override IEnumerable<(DateTime ts, int kwh)> ReadBatch(int count)
        {
            foreach (var dataPoint in _ingestor.ReadBatch(count))
            {
                if (_random.NextDouble() < _outageProbability)
                {
                    yield return (dataPoint.ts, 0);
                }
                else
                {
                    yield return dataPoint;
                }
            }
        }
    }
}
