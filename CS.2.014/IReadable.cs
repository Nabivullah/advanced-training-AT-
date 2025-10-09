using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS._2._014
{
    internal interface IReadable
    {
        int ReadKwh();             // returns delta since last poll
        public string SourceId { get; }
    }
}
