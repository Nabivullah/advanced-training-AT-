using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS._3._020
{
    class VoltageEvent: Event
    {
        //(Category="VOLTAGE", Severity=2, plus Voltage)
        public double Voltage { get; }
        public VoltageEvent(DateTime when, string meterSerial, double voltage)
            : base(when, meterSerial)
        {
            Voltage = voltage;
        }
        public override string Category => "VOLTAGE";
        public override int Severity => 2;
        public override string Describe() => $"{base.Describe()} | Voltage: {Voltage}V";

    }
}
