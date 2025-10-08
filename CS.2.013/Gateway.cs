using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS._2._013
{
    class Gateway : Device
    {
        public string IpAddress;
        public override string Describe()
        {
            return $"Gateway Id:{Id}| InstalledOn: {InstalledOn} | IpAddress: {IpAddress}";
        }
    }
}
