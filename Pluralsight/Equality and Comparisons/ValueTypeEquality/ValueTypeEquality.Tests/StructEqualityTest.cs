using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ValueTypeEquality.Tests
{
    [TestClass]
    public class StructEqualityTest
    {
        FoodItem banana;
        FoodItem banana2;
        FoodItem steak;

        [TestInitialize]
        public void TestInitialize()
        {
            banana = new FoodItem("Banana", FoodGroup.Fruit);
            banana2 = new FoodItem("Banana", FoodGroup.Fruit);
            steak = new FoodItem("Steak", FoodGroup.Meat);
        } 

        [TestMethod]
        public void TestOperator()
        {
            Assert.IsTrue(banana == banana2);
            Assert.IsFalse(banana != banana2);
            Assert.IsFalse(banana == steak);
        }

        [TestMethod]
        public void TestIEquatable()
        {
            Assert.IsTrue(banana.Equals(banana2));
            Assert.IsFalse(banana.Equals(steak));
        }

        [TestMethod]
        public void TestObjectEquals()
        {
            Assert.IsTrue(banana.Equals((object)banana2));
            Assert.IsFalse(banana.Equals((object)steak));
        }

        [TestMethod]
        public void TestHashCode()
        {
            Assert.IsTrue(banana.GetHashCode() == banana2.GetHashCode());
            Assert.IsFalse(banana.GetHashCode() == steak.GetHashCode());
        }
    }
}
