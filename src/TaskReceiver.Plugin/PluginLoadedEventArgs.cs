using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskReceiver.Plugin
{
    public class PluginLoadedEventArgs : EventArgs
    {
        public PluginLoadedEventArgs(ITaskReciverPlugin plugin)
        {
            this.plugin = plugin;
        }

        public ITaskReciverPlugin plugin { get; private set; }
    }
}
