using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS._3._020
{
    class OutageEvent : Event
    {
        //(Category = "OUTAGE", Severity = 3, plus DurationMinutes)
        public int DurationMinutes { get; }
        public OutageEvent(DateTime when, string meterSerial, int durationMinutes)
            : base(when, meterSerial)
        {
            DurationMinutes = durationMinutes;
        }
        public override string Category => "OUTAGE";
        public override int Severity => 3;
        public override string Describe() => $"{base.Describe()} | Duration: {DurationMinutes}min";

    }
}
