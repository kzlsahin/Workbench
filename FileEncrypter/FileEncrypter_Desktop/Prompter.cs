using FileEncrypterCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Interop;

namespace FileEncrypter_Desktop
{
    public class Prompter : IPrompter
    {
        TextBox _textBox;
        public Prompter(TextBox label)
        {
            _textBox = label;
        }

        void IPrompter.WriteLine(string msg)
        {
            _textBox.Text += "> " + msg + "\n";
        }
    }
}
