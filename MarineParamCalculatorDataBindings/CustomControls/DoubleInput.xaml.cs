﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
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
        DependencyProperty.Register("Value", typeof(double), typeof(DoubleInput), new PropertyMetadata(0.0, OnDependencyValueChanged));

        protected double _value = 0;
        protected string _decimalSeperator => CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
        public DoubleInput()
        {
            InitializeComponent();
        }
        public event EventHandler? ValueChanged;
        public event PropertyChangedEventHandler? PropertyChanged;

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
            return _decimalSeperator.Contains(lastEntry)
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
                    SetValue(ValueProperty, value);
                    this.Text = _value.ToString();
                }
            }
        }
        // Expose Text property for easy access
        public string Text
        {
            get { return textBox.Text; }
            set 
            { 
                textBox.Text = value;
            }
        }
        protected void NumericTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Check if the entered text is a valid numeric value
            if (double.TryParse(Text, out double val))
            {
                Value = val;
                ValueChanged?.Invoke(this, e);
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
