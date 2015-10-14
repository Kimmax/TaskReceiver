using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TaskReceiver.Plugin
{
    public class PluginLoader
    {
        private string[] dllFileNames = null;
        public ICollection<ITaskReciverPlugin> LoadedPlugins { get; private set; }

        public PluginLoader(string pluginDir)
        {
            if (Directory.Exists(pluginDir))
            {
                dllFileNames = Directory.GetFiles(pluginDir, "*.dll");
            }
            else
            {
                Directory.CreateDirectory(pluginDir);
            }
        }

        public void LoadAll()
        {
            LoadedPlugins = new List<ITaskReciverPlugin>();

            foreach (string dllFile in dllFileNames)
            {
                AssemblyName an = AssemblyName.GetAssemblyName(dllFile);
                Assembly assembly = Assembly.Load(an);

                Type pluginType = typeof(ITaskReciverPlugin);

                if (assembly != null)
                {
                    Type[] types = assembly.GetTypes();
                    foreach (Type type in types)
                    {
                        if (type.IsInterface || type.IsAbstract)
                        {
                            continue;
                        }
                        else
                        {
                            if (type.GetInterface(pluginType.FullName) != null)
                            {
                                ITaskReciverPlugin plugin = (ITaskReciverPlugin)Activator.CreateInstance(type);
                                LoadedPlugins.Add(plugin); 
                            }
                        }
                    }
                }
            }
        }
    }
}
