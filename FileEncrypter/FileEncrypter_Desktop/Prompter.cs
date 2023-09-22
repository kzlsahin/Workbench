using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FileEncrypter_Desktop
{
    public class Prompter
    {
        public Action<string> WriteLine { get; set; }

        TextBlock _textBlock;
        TextBox _textBox;
        public Prompter(TextBlock label)
        {
            _textBlock = label;
            WriteLine = WriteLineToLabel;
        }
        public Prompter(TextBox textBox)
        {
            _textBox = textBox;
            WriteLine = WriteLineToTextBox;
        }
        void WriteLineToLabel(string msg)
        {
            _textBlock.Text += "> " + msg + "\n";
        }
        void WriteLineToTextBox(string msg) 
        {
            _textBox.AppendText("> " + msg + "\n");
            _textBox.ScrollToEnd();
        }
    }
}
