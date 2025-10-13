using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS._3._020
{
    class EventProcessor
    {
        public static void PrintTopSevere(IEnumerable<Event> events, int topN)
        {
            // sort by Severity desc, then When desc; print Describe() + extra fields polymorphically
            var topEvents = events
                .OrderByDescending(e => e.Severity)
                .ThenByDescending(e => e.When)
                .Take(topN);
            foreach (var ev in topEvents)
                {
                Console.WriteLine(ev.Describe());
            }

        }
    }
}
