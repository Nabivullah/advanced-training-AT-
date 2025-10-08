using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS._2._013
{
    class Meter : Device
    {
        public int Phases;

        public override string Describe()
        {
            return $"Meter Id:{Id}| InstalledOn: {InstalledOn} | PhaseCount: {Phases}";
        }
    }
}
