using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS._3._017
{
    class PeakOveruseRule : AlarmRule
    {
        private readonly int _threshold;
        public PeakOveruseRule(int threshold) : base("PeakOveruse") => _threshold = threshold; //derived constuctor with name initialization for this class
        public override bool IsTriggered(LoadProfileDay day) => day.Total > _threshold; //gives true if satisfieds
}
}
