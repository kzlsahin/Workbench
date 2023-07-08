using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISO_12217.Units
{
    public record struct Meter
    {
        public double Value { get; set; }
        public Meter(double value)
        {
            Value = value;
        }
        public static implicit operator Meter(double value)
        {
            return new Meter(value);
        }
        public static implicit operator Meter(float value)
        {
            return new Meter(value);
        }
        public static implicit operator Meter(int value)
        {
            return new Meter(value);
        }
        public static implicit operator Meter(Centimeter cm)
        {
            return new Meter(cm.Value * 100);
        }
        public static implicit operator Meter(Milimeter mm)
        {
            return new Meter(mm.Value * 1000);
        }
        public static Meter operator +(Meter a) => a;
        public static Meter operator -(Meter a) => (-1) * a;
        public static Meter operator *(Meter a, Meter b) => new Meter(a.Value * b.Value);
        public static Meter operator *(double d, Meter a) => new Meter(d*a.Value);
        public static Meter operator *(Meter a, double d) => new Meter(d*a.Value);
        public static Meter operator /(Meter a, Meter b) => new Meter(a.Value/b.Value);
        public static Meter operator /(double d, Meter a) => new Meter(d/a.Value);
        public static Meter operator /(Meter a, double d) => new Meter(a.Value/d);
        public static Meter operator +(Meter a, Meter b) => new Meter(a.Value + b.Value);
        public static Meter operator +(double d, Meter a) => new Meter(d + a.Value);
        public static Meter operator +(Meter a, double d) => new Meter(d + a.Value);
        public static Meter operator -(Meter a, Meter b) => new Meter(a.Value - b.Value);
        public static Meter operator -(double d, Meter a) => new Meter(d - a.Value);
        public static Meter operator -(Meter a, double d) => new Meter(d - a.Value);

        // **** when struct is defined as record these equality checks comes by default.
        //public static bool operator ==(Meter a, Meter b) => a.Value == b.Value;
        //public static bool operator !=(Meter a, Meter b) => a.Value != b.Value;
        // ****
        public static bool operator <(Meter a, Meter b) => a.Value < b.Value;
        public static bool operator >(Meter a, Meter b) => a.Value > b.Value;
        public static bool operator <=(Meter a, Meter b) => a.Value <= b.Value;
        public static bool operator >=(Meter a, Meter b) => a.Value >= b.Value;
    }
}
