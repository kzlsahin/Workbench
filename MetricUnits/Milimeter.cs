using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISO_12217.Units
{
    public record struct Milimeter
    {
        public double Value { get; set; }
        public Milimeter(double value)
        {
            Value = value;
        }
        public static implicit operator Milimeter(double value)
        {
            return new Milimeter(value);
        }
        public static implicit operator Milimeter(float value)
        {
            return new Milimeter(value);
        }
        public static implicit operator Milimeter(int value)
        {
            return new Milimeter(value);
        }
        public static implicit operator Milimeter(Centimeter cm)
        {
            return new Meter(cm.Value / 10);
        }
        public static implicit operator Milimeter(Meter mm)
        {
            return new Meter(mm.Value / 1000);
        }
        public static Milimeter operator +(Milimeter a) => a;
        public static Milimeter operator -(Milimeter a) => (-1) * a;
        public static Milimeter operator *(Milimeter a, Milimeter b) => new Milimeter(a.Value * b.Value);
        public static Milimeter operator *(double d, Milimeter a) => new Milimeter(d * a.Value);
        public static Milimeter operator *(Milimeter a, double d) => new Milimeter(d * a.Value);
        public static Milimeter operator /(Milimeter a, Milimeter b) => new Milimeter(a.Value / b.Value);
        public static Milimeter operator /(double d, Milimeter a) => new Milimeter(d / a.Value);
        public static Milimeter operator /(Milimeter a, double d) => new Milimeter(a.Value / d);
        public static Milimeter operator +(Milimeter a, Milimeter b) => new Milimeter(a.Value + b.Value);
        public static Milimeter operator +(double d, Milimeter a) => new Milimeter(d + a.Value);
        public static Milimeter operator +(Milimeter a, double d) => new Milimeter(d + a.Value);
        public static Milimeter operator -(Milimeter a, Milimeter b) => new Milimeter(a.Value - b.Value);
        public static Milimeter operator -(double d, Milimeter a) => new Milimeter(d - a.Value);
        public static Milimeter operator -(Milimeter a, double d) => new Milimeter(d - a.Value);

        // **** when struct is defined as record these equality checks comes by default.
        //public static bool operator ==(Milimeter a, Milimeter b) => a.Value == b.Value;
        //public static bool operator !=(Milimeter a, Milimeter b) => a.Value != b.Value;
        // ****
        public static bool operator <(Milimeter a, Milimeter b) => a.Value < b.Value;
        public static bool operator >(Milimeter a, Milimeter b) => a.Value > b.Value;
        public static bool operator <=(Milimeter a, Milimeter b) => a.Value <= b.Value;
        public static bool operator >=(Milimeter a, Milimeter b) => a.Value >= b.Value;
    }
}
