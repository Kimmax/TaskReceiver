using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskReceiver.Plugin
{
    public interface ITaskReciverPlugin
    {
        string PluginName { get;  }
        string CommandTrigger { get; }

        void Execute(List<Tuple<string, string>> param);
    }
}
