using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskReceiver.Backend;

namespace TaskReceiver.Frontend
{
    class CommandEcho : Command
    {
        public CommandEcho(string trigger) : base(trigger) {}

        public override void Execute(List<Tuple<string, string>> param)
        {
            Console.WriteLine("CommandEcho:" + param[0].Item1);
        }
    }
}
