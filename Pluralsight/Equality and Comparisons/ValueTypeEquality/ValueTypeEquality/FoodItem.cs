using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueTypeEquality
{
    public enum FoodGroup { Meat, Fruit, Vegetables, Sweets }

    public struct FoodItem : IEquatable<FoodItem>
    {
        private readonly string name;
        private readonly FoodGroup group;

        public string Name { get { return name; } }

        public FoodGroup Group { get { return group; } }

        public FoodItem(string name, FoodGroup group)
        {
            this.name = name;
            this.group = group;
        }

        public override string ToString()
        {
            return name;
        }

        public bool Equals(FoodItem other)
        {
            return this.name == other.Name && this.group == other.Group;
        }

        public override bool Equals(object obj)
        {
            if (obj is FoodItem)
            {
                return Equals((FoodItem)obj);
            }
            else
            {
                return false;
            }
        }

        public static bool operator ==(FoodItem lhs, FoodItem rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(FoodItem lhs, FoodItem rhs)
        {
            return !(lhs.Equals(rhs));
        }

        public override int GetHashCode()
        {
            return name.GetHashCode() ^ group.GetHashCode();
        }
    }
}
