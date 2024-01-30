using Avalonia.Controls;
using FileEncrypterCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvalonCrypter
{
    internal class Prompter: IPrompter
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
