using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicParser
{
    interface IBoolLayer
    {
        Boolean EvalBool(Dictionary<string, string> sbjInfo);
    }
}
