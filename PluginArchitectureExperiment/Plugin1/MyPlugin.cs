using PlugDep;
using Plugin_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Plugin1
{
    public class MyPlugin : IPluginCommand
    {
        public ILogger Logger { get; set; }
        public string Name { get; set; }

        public void Execute()
        {
            if (Logger == null) return;
            Logger.Log("I am Plugin2");
            Logger.Log((new PlugDependency()).GetName());
        }
    }
}
