using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ACM.BL;

namespace ACM.BLTest
{
    [TestClass]
    public class CustomerTest
    {
        [TestMethod]
        public void FullNameTestValid()
        {
            // Arrange
            var customer = new BL.Customer();
            customer.FirstName = "Bilbo";
            customer.LastName = "Baggins";

            var expected = "Baggins, Bilbo";

            // Act
            var actual = customer.FullName;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FullNameFirstNameEmpty()
        {
            // Arrange
            var customer = new BL.Customer();
            customer.LastName = "Baggins";

            var expected = "Baggins";

            // Act
            var actual = customer.FullName;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FullNameLastNameEmpty()
        {
            // Arrange
            var customer = new BL.Customer();
            customer.FirstName = "Bilbo";

            var expected = "Bilbo";

            // Act
            var actual = customer.FullName;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IntegerTypeTest()
        {
            // Arrange
            int i1;
            i1 = 42;

            // Act
            int i2 = i1;
            i2 = 2;

            // Assert
            Assert.AreEqual(42, i1);
        }

        [TestMethod]
        public void ObjectTypeTest()
        {
            // Arrange
            var c1 = new BL.Customer();
            c1.FirstName = "Bilbo";

            // Act
            var c2 = c1;
            c2.FirstName = "Frodo";

            // Assert
            Assert.AreEqual("Frodo", c1.FirstName);
        }

        [TestMethod]
        public void ValidateValid()
        {
            // Arrange
            var customer = new BL.Customer();
            customer.LastName = "Baggins";
            customer.EmailAddress = "fbaggins@hobbiton.me";

            var expected = true;

            // Act
            var actual = customer.Validate();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidateMissingLastName()
        {
            // Arrange
            var customer = new BL.Customer();
            customer.EmailAddress = "fbaggins@hobbiton.me";

            var expected = false;

            // Act
            var actual = customer.Validate();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
