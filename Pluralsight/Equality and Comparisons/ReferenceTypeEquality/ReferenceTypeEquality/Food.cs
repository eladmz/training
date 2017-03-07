using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceTypeEquality
{
    public enum FoodGroup { Meat, Fruit, Vegetables, Sweets }

    public class Food
    {
        private readonly string name;
        private readonly FoodGroup group;

        public string Name { get { return name; } }

        public FoodGroup Group { get { return group; } }

        public Food(string name, FoodGroup group)
        {
            this.name = name;
            this.group = group;
        }

        public override string ToString()
        {
            return name;
        }

        public static bool operator ==(Food x, Food y)
        {
            return object.Equals(x, y);
        }

        public static bool operator !=(Food x, Food y)
        {
            return !object.Equals(x, y);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (ReferenceEquals(obj, this))
                return true;
            if (obj.GetType() != this.GetType())
                return false;
            Food rhs = obj as Food;
            return this.name == rhs.Name && this.group == rhs.Group;
        }

        public override int GetHashCode()
        {
            return this.name.GetHashCode() ^ this.group.GetHashCode();
        }

    }
}
