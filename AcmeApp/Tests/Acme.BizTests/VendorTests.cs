using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acme.Common;

namespace Acme.Biz.Tests
{
    [TestClass()]
    public class VendorTests
    {
        [TestMethod()]
        public void SendWelcomeEmail_ValidCompany_Success()
        {
            // Arrange
            var vendor = new Vendor();
            vendor.CompanyName = "ABC Corp";
            var expected = "Message sent: Hello ABC Corp";

            // Act
            var actual = vendor.SendWelcomeEmail("Test Message");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SendWelcomeEmail_EmptyCompany_Success()
        {
            // Arrange
            var vendor = new Vendor();
            vendor.CompanyName = "";
            var expected = "Message sent: Hello";

            // Act
            var actual = vendor.SendWelcomeEmail("Test Message");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SendWelcomeEmail_NullCompany_Success()
        {
            // Arrange
            var vendor = new Vendor();
            vendor.CompanyName = null;
            var expected = "Message sent: Hello";

            // Act
            var actual = vendor.SendWelcomeEmail("Test Message");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void PlaceOrderTest()
        {
            //Arrange
            Vendor vendor = new Vendor();
            Product product = new Product(1, "Saw", "");

            OperationResult expected = new OperationResult(true, "Order from Acme, Inc\r\nProduct: Tools-0001\r\nQuantity: 12\r\nInstructions: standard delivery");

            // Act
            OperationResult actual = vendor.PlaceOrder(product, 12);

            // Assert
            Assert.AreEqual(expected.Success, actual.Success);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod()]
        public void PlaceOrderTest_3Parameters()
        {
            //Arrange
            Vendor vendor = new Vendor();
            Product product = new Product(1, "Saw", "");

            OperationResult expected = new OperationResult(true,
                "Order from Acme, Inc\r\nProduct: Tools-0001\r\nQuantity: 12\r\nDeliver By: 25/10/2017\r\nInstructions: standard delivery");

            // Act
            OperationResult actual = vendor.PlaceOrder(product, 12, new DateTimeOffset(2017, 10, 25, 0, 0, 0, new TimeSpan(-7, 0, 0)));

            // Assert
            Assert.AreEqual(expected.Success, actual.Success);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PlaceOrder_NullProduct_Exception()
        {
            //Arrange
            Vendor vendor = new Vendor();

            // Act
            OperationResult actual = vendor.PlaceOrder(null, 12);

            // Assert
            // Expected exception
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PlaceOrder_InvalidQuantity_Exception()
        {
            //Arrange
            Vendor vendor = new Vendor();
            Product product = new Product(1, "Saw", "");

            // Act
            OperationResult actual = vendor.PlaceOrder(product, 0);

            // Assert
            // Expected exception
        }

        [TestMethod()]
        public void PlaceOrderTest_WithAddress()
        {
            //Arrange
            Vendor vendor = new Vendor();
            Product product = new Product(1, "Saw", "");

            OperationResult expected = new OperationResult(true, "Test With Address");

            // Act
            // OperationResult actual = vendor.PlaceOrder(product, 12, includeAddress: true, sendCopy: false);
            OperationResult actual = vendor.PlaceOrder(product, 12, Vendor.IncludeAddress.Yes, Vendor.SendCopy.No);

            // Assert
            Assert.AreEqual(expected.Success, actual.Success);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod()]
        public void PlaceOrderTest_NoDeliveryDate()
        {
            //Arrange
            Vendor vendor = new Vendor();
            Product product = new Product(1, "Saw", "");

            OperationResult expected = new OperationResult(true,
                "Order from Acme, Inc\r\nProduct: Tools-0001\r\nQuantity: 12\r\nInstructions: Deliver to Suite 42");

            // Act
            OperationResult actual = vendor.PlaceOrder(product, 12, instructions: "Deliver to Suite 42");

            // Assert
            Assert.AreEqual(expected.Success, actual.Success);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            // Arrange
            Vendor vendor = new Vendor();
            vendor.VendorId = 1;
            vendor.CompanyName = "ABC Corp";

            string expected = "Vendor: ABC Corp";

            // Act
            string actual = vendor.ToString();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void PrepareDirectionsTest()
        {
            // Arrange
            Vendor vendor = new Vendor();

            string expected = @"Insert \r\n to define a new line";

            // Act
            string actual = vendor.PrepareDirections();
            Console.WriteLine(actual);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}