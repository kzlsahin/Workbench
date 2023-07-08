using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISO_12217.Units
{
    public record struct Centimeter
    {
        public double Value { get; set; }
        public Centimeter(double value)
        {
            Value = value;
        }
        public static implicit operator Centimeter(double value)
        {
            return new Centimeter(value);
        }
        public static implicit operator Centimeter(float value)
        {
            return new Centimeter(value);
        }
        public static implicit operator Centimeter(int value)
        {
            return new Centimeter(value);
        }
        public static implicit operator Centimeter(Meter cm)
        {
            return new Meter(cm.Value / 100);
        }
        public static implicit operator Centimeter(Milimeter mm)
        {
            return new Meter(mm.Value * 10);
        }
        public static Centimeter operator +(Centimeter a) => a;
        public static Centimeter operator -(Centimeter a) => (-1) * a;
        public static Centimeter operator *(Centimeter a, Centimeter b) => new Centimeter(a.Value * b.Value);
        public static Centimeter operator *(double d, Centimeter a) => new Centimeter(d * a.Value);
        public static Centimeter operator *(Centimeter a, double d) => new Centimeter(d * a.Value);
        public static Centimeter operator /(Centimeter a, Centimeter b) => new Centimeter(a.Value / b.Value);
        public static Centimeter operator /(double d, Centimeter a) => new Centimeter(d / a.Value);
        public static Centimeter operator /(Centimeter a, double d) => new Centimeter(a.Value / d);
        public static Centimeter operator +(Centimeter a, Centimeter b) => new Centimeter(a.Value + b.Value);
        public static Centimeter operator +(double d, Centimeter a) => new Centimeter(d + a.Value);
        public static Centimeter operator +(Centimeter a, double d) => new Centimeter(d + a.Value);
        public static Centimeter operator -(Centimeter a, Centimeter b) => new Centimeter(a.Value - b.Value);
        public static Centimeter operator -(double d, Centimeter a) => new Centimeter(d - a.Value);
        public static Centimeter operator -(Centimeter a, double d) => new Centimeter(d - a.Value);

        // **** when struct is defined as record these equality checks comes by default.
        //public static bool operator ==(Centimeter a, Centimeter b) => a.Value == b.Value;
        //public static bool operator !=(Centimeter a, Centimeter b) => a.Value != b.Value;
        // ****
        public static bool operator <(Centimeter a, Centimeter b) => a.Value < b.Value;
        public static bool operator >(Centimeter a, Centimeter b) => a.Value > b.Value;
        public static bool operator <=(Centimeter a, Centimeter b) => a.Value <= b.Value;
        public static bool operator >=(Centimeter a, Centimeter b) => a.Value >= b.Value;
    }
}
