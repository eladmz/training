using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades.Tests.Types
{
    [TestClass]
    public class TypeTests
    {
        [TestMethod]
        public void UsingArrays()
        {
            float[] grades;
            grades = new float[3];

            AddGrades(grades);

            Assert.AreEqual(89.1f, grades[1]);
        }

        private void AddGrades(float[] grades)
        {
            grades[1] = 89.1f;
        }

        [TestMethod]
        public void UppercaseString()
        {
            // strings are reference type that behave as a value type!!
            string name = "elad";
            name = name.ToUpper();

            Assert.AreEqual("ELAD", name);
        }

        [TestMethod]
        public void AddDateToDateTime()
        {
            DateTime date = new DateTime(2015, 1, 1);
            date = date.AddDays(1);

            Assert.AreEqual(2, date.Day);
        }

        [TestMethod]
        public void ValueTypesPassByValue()
        {
            int x = 46;

            IncrementNumber(x);
            Assert.AreEqual(46, x);
        }

        private void IncrementNumber(int num)
        {
            num += 1;
        }

        [TestMethod]
        public void ReferenceTypesPassByValue()
        {
            GradeBook book1 = new GradeBook();
            GradeBook book2 = book1;

            book1.Name = "Something Else";

            GiveBookAName(book2);
            Assert.AreEqual("A GradeBook", book1.Name);
        }

        private void GiveBookAName(GradeBook book)
        {
            // This will cause the test to fail because the book variable is passed by value (in this case the value
            // is the pointer of the object) so the variables book1,book2 in ReferenceTypesPassByValue will NOT be affected.
            // book = new GradeBook();
            book.Name = "A GradeBook";
        }

        [TestMethod]
        public void StringComparisons()
        {
            string name1 = "Elad";
            string name2 = "elad";

            bool result = string.Equals(name1, name2, StringComparison.InvariantCultureIgnoreCase);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IntVariablesGoldAValue()
        {
            int x1 = 100;
            int x2 = x1;

            x1 = 4;
            Assert.AreNotEqual(x1, x2);
        }

        [TestMethod]
        public void GradeBookVariablesHoldAReference()
        {
            GradeBook g1 = new GradeBook();
            GradeBook g2 = g1;

            g1.Name = "Elad's grade book";

            Assert.AreEqual(g1.Name, g2.Name);
        }

        [TestMethod]
        public void StringVariablesHoldAReference()
        {
            string greeting = "Hello, World";
            string copy = greeting;

            Assert.AreSame(greeting, copy);
        }
    }
}
