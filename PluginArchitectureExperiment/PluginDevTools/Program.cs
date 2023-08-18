using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Plugin1;
using ClassRules_RefObjects;

namespace PluginDevTools
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Assembly ass = Assembly.GetAssembly(typeof(ClassRules_RefObjects.Plate));
            string assName = ass.FullName;
            Console.WriteLine(assName);
            string path = Path.Combine("output", "PluginDevToolsOutput.txt");
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            if (!Directory.Exists(Path.GetDirectoryName(path)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(path));
            }
            File.WriteAllText(path, assName);

            Console.Read();
        }

    }
}
