using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS._3._017
{
    abstract class AlarmRule
    {

        public string Name { get; } 
        protected AlarmRule(string name) => Name = name;
        public abstract bool IsTriggered(LoadProfileDay day); // No initialization as it is an abstract class
        public virtual string Message(LoadProfileDay day)
            => $"{Name} triggered on {day.Date:yyyy-MM-dd}"; // Message class which can be overridden later


    }
}
