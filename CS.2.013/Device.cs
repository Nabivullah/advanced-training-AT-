using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS._2._013
{
    class Device
    {
        public string Id;
        public DateTime InstalledOn = DateTime.Now;


        //Method: Virtual Describe() → "Device Id: ... InstalledOn: ..."
        public virtual string Describe()
        {
            return $"Device Id: {Id} InstalledOn: {InstalledOn}";
        }
    }
}
