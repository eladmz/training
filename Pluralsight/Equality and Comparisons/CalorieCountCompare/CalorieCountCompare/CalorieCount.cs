using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCountCompare
{
    public struct CalorieCount : IComparable<CalorieCount>, IEquatable<CalorieCount>, IComparable
    {
        private float value;
        public float Value { get { return value; } }

        public CalorieCount(float value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return value + " cal";
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
                throw new ArgumentNullException("obj");
            if (!(obj is CalorieCount))
                throw new ArgumentException("Expected CalorieCount instance", "obj");
            return CompareTo((CalorieCount)obj);
        }

        public int CompareTo(CalorieCount other)
        {
            return this.value.CompareTo(other.value);
        }

        public bool Equals(CalorieCount other)
        {
            return value == other.value;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (!(obj is CalorieCount))
                return false;
            return value == ((CalorieCount)obj).value;
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        public static bool operator ==(CalorieCount x, CalorieCount y)
        {
            return x.value == y.value;
        }

        public static bool operator !=(CalorieCount x, CalorieCount y)
        {
            return x.value != y.value;
        }

        public static bool operator <(CalorieCount x, CalorieCount y)
        {
            return x.value < y.value;
        }

        public static bool operator <=(CalorieCount x, CalorieCount y)
        {
            return x.value <= y.value;
        }

        public static bool operator >(CalorieCount x, CalorieCount y)
        {
            return x.value > y.value;
        }

        public static bool operator >=(CalorieCount x, CalorieCount y)
        {
            return x.value >= y.value;
        }
    }
}
