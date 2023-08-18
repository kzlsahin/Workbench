using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin_Interfaces
{
    public interface IPluginCommand
    {
        string Name { get; set; }
        ILogger Logger { get; set; }
        void Execute();
    }
}
