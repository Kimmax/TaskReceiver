using Bend.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using TaskReceiver.Plugin;

namespace TaskReceiver.Backend
{
    public class TaskServServer: HttpServer 
    {
        PluginLoader pluginLoader = new PluginLoader(Path.Combine(Assembly.GetExecutingAssembly().CodeBase, @"\plugins"));

        public TaskServServer(int port) : base(port) 
        {
            Console.WriteLine("Server listing on port " + port + "\n");
            pluginLoader.LoadAll();
        }

        public override void handleGETRequest(HttpProcessor processor)
        {
            Console.WriteLine("--GET REQUEST BEGIN--");
            Console.WriteLine("Request:\n\t" + processor.http_url);
            Console.WriteLine("Parameter:");

            Console.WriteLine("\nSearching Handler..");
            foreach (ITaskReciverPlugin cmd in pluginLoader.LoadedPlugins)
            {
                if (processor.http_url.StartsWith(cmd.CommandTrigger))
                {
                    Console.Write(" Found!");

                    List<Tuple<string, string>> param = new List<Tuple<string,string>>();

                    param = GetParams(processor.http_url, cmd.CommandTrigger);

                    param.ForEach(x => Console.WriteLine("\t" + x.Item1 + " = " + ((x.Item2 == "") ? "no value" : x.Item2)));
                    
                    Console.WriteLine("Executing!");
                    Console.WriteLine("--GET REQUEST END--\n");

                    cmd.Execute(param);
                    processor.writeSuccess();
                    return;
                }
            }

            processor.writeFailure();
            Console.Write(" Non Found :(");
            Console.WriteLine("--GET REQUEST END--");
        }
    
        public override void handlePOSTRequest(HttpProcessor p, StreamReader inputData) {
            Console.WriteLine("--POST REQUEST BEGIN--");
            Console.WriteLine("Request:\n\t" + p.http_url);
            Console.WriteLine("Answer:\n\tPost request not supported.");
            Console.WriteLine("--POST REQUEST END--\n");
        }

        /* Builds a list with all params contained in GET request */
        static List<Tuple<string, string>> GetParams(string url, string trigger)
        {
            List<Tuple<string, string>> param = new List<Tuple<string, string>>();

            string paramString = Regex.Split(url, trigger)[1];

            foreach (String s in paramString.Split('/'))
            {
                if (string.IsNullOrEmpty(s) || string.IsNullOrWhiteSpace(s))
                    continue;

                if(s.Contains("="))
                {
                    param.Add(new Tuple<string, string>(s.Split('=')[0], s.Split('=')[1]));
                }
                else
                {
                    param.Add(new Tuple<string, string>(s, ""));
                }
            }

            return param;
        }
    }
}
