using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceTypeEquality
{
    public sealed class CookedFood : Food, IEquatable<CookedFood>
    {
        private string cookingMethod;

        public string CookingMethod { get { return cookingMethod; } }

        public CookedFood(string cookingMethod, string name, FoodGroup group) : base(name, group)
        {
            this.cookingMethod = cookingMethod;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", cookingMethod, Name);
        }

        public override bool Equals(object obj)
        {
            if (!base.Equals(obj))
                return false;
            CookedFood rhs = (CookedFood)obj;
            return this.cookingMethod == rhs.CookingMethod;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ this.cookingMethod.GetHashCode();
        }

        // this good only for sealed classes but it's better not to do it on reference types
        public bool Equals(CookedFood other)
        {
            if (!base.Equals(other))
                return false;
            return this.cookingMethod == other.CookingMethod;
        }

        public static bool operator ==(CookedFood x, CookedFood y)
        {
            return object.Equals(x, y);
        }

        public static bool operator !=(CookedFood x, CookedFood y)
        {
            return !object.Equals(x, y);
        }
    }
}
