using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskServ_Backend;

namespace TaskServ_Frontend
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
