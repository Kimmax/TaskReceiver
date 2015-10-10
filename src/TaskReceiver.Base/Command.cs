using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskServ_Backend
{
    public abstract class Command
    {
        public string CommandTrigger { get; private set; }
 
        public Command(string trigger)
        {
            this.CommandTrigger = trigger;
        }

        public abstract void Execute(List<Tuple<string, string>> param);
    }
}
