using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace MarineParamCalculatorDataBindings.Controls
{
    /// <summary>
    /// Control for double type inputs and bindable Value property.
    /// </summary>
    public partial class DoubleInput : UserControl
    {
        public static readonly DependencyProperty ValueProperty =
        DependencyProperty.Register("Value", typeof(double), typeof(DoubleInput), new PropertyMetadata(0.0, OnDependencyValueChanged));

        public string FormatString { get; set; } = "";
        public bool TrimTrailingZerosAfterDecimal = true;
        protected double _value = 0;
        protected string _decimalSeperator => CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
        protected bool _localTextUpdate = false;
        public DoubleInput()
        {
            InitializeComponent();
        }
        public event EventHandler? InputEntered;
        public event PropertyChangedEventHandler? PropertyChanged;

        public double Value
        {
            get => _value;
            set
            {
                if (_value != value)
                {
                    _value = value;
                    string txt = _value.ToString(FormatString);
                    if (TrimTrailingZerosAfterDecimal)
                    {
                        txt = txt.TrimEnd('0');
                    }
                    Text = txt;
                }
            }
        }
        // Expose Text property for easy access
        public string Text
        {
            get { return textBox.Text; }
            private set
            {
                if (value != textBox.Text)
                {
                    _localTextUpdate = true;
                    textBox.Text = value;
                }
            }
        }
        protected void NumericTextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!IsNumericTextAllowed(e.Text))
            {
                e.Handled = true;
            }
        }

        protected bool IsNumericTextAllowed(string text)
        {
            // Check if the entered text is a valid numeric value (allow '.' as well)
            char lastEntry = text[text.Length - 1];
            return
                (_decimalSeperator.Contains(lastEntry) && !Text.Contains(lastEntry))
                || (Text.Length == 0 && lastEntry == '-')
                || Char.IsDigit(lastEntry);
        }
        protected void NumericTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_localTextUpdate)
            {
                // text changed by Value
                // if text is updated by own class do not loop back to the Value property
                _localTextUpdate = false;
            }
            else
            {
                // Text Changed by user input
                // Check if the entered text is a valid numeric value
                if (double.TryParse(Text, out double val))
                {
                    _value = val;
                    SetValue(ValueProperty, val);
                    InputEntered?.Invoke(this, e);
                }
            }
        }
        protected static void OnDependencyValueChanged(object dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            string propName = e.Property.Name;
            Type thisType = typeof(DoubleInput);
            PropertyInfo? myPropInfo = thisType.GetProperty(propName);
            if (myPropInfo is null)
                return;
            myPropInfo.SetValue(dependencyObject, e.NewValue);
        }
    }
}
