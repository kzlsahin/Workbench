using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileEncrypterCore
{
    public interface IPrompter
    {
        void WriteLine(string message);
    }
}
