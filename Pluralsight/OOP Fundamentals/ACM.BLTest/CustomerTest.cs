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
            var customer = new Customer();
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
            var customer = new Customer();
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
            var customer = new Customer();
            customer.FirstName = "Bilbo";

            var expected = "Bilbo";

            // Act
            var actual = customer.FullName;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
