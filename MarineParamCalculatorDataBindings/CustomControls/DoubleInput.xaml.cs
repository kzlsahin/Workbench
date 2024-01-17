using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MarineParamCalculatorDataBindings.Controls
{
    /// <summary>
    /// Interaction logic for DoubleInput.xaml
    /// </summary>
    public partial class DoubleInput : UserControl
    {
        public static readonly DependencyProperty ValueProperty =
        DependencyProperty.Register("Value", typeof(double), typeof(DoubleInput), new PropertyMetadata(0.0));

        private double _value;
        public DoubleInput()
        {
            InitializeComponent();
        }
        public event EventHandler? ValueChanged;
        private void NumericTextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!IsNumericTextAllowed(e.Text))
            {
                e.Handled = true;
            }
        }

        private bool IsNumericTextAllowed(string text)
        {
            // Check if the entered text is a valid numeric value (allow '.' as well)
            char lastEntry = text[text.Length - 1];
            return lastEntry == '.'
                || lastEntry == '-'
                || Char.IsDigit(lastEntry);
        }

        public double Value
        {
            get => _value;
            set
            {
                if (_value != value)
                {
                    _value = value;
                    this.Text = _value.ToString();
                }
            }
        }
        // Expose Text property for easy access
        public string Text
        {
            get { return numericTextBox.Text; }
            set { numericTextBox.Text = value; }
        }
        private void numericTextBox_LostFocus(object sender, TextChangedEventArgs e)
        {
            // Check if the entered text is a valid numeric value
            if (double.TryParse(Text, out double val))
            {
                _value = val;
                ValueChanged?.Invoke(this, e);
            }
        }
    }
}
