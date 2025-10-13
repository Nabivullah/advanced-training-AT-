using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS._3._020
{
    class TamperEvent : Event
    {
        //(Category="TAMPER", Severity=5, plus Code)
        public string Code { get; }
        public TamperEvent(DateTime when, string meterSerial, string code)
            : base(when, meterSerial)
        {
            Code = code;
        }
        public override string Category => "TAMPER";
        public override int Severity => 5;
        public override string Describe() => $"{base.Describe()} | Code: {Code}";

    }
}
