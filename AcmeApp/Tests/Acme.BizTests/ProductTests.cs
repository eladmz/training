using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz.Tests
{
    [TestClass()]
    public class ProductTests
    {
        [TestMethod()]
        public void SayHelloTest()
        {
            //Arrange
            Product currentProduct = new Product();
            currentProduct.ProductName = "Saw";
            currentProduct.ProductId = 1;
            currentProduct.Description = "15-inch steel blade hand saw";
            currentProduct.ProductVendor.CompanyName = "ABC Corp";
            string expected = "Hello Saw (1): 15-inch steel blade hand saw" + " Available on: ";

            //Act
            string actual = currentProduct.SayHello();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SayHello_ParameterizedConstuctor()
        {
            //Arrange
            Product currentProduct = new Product(1, "Saw", "15-inch steel blade hand saw");
            string expected = "Hello Saw (1): 15-inch steel blade hand saw" + " Available on: ";

            //Act
            string actual = currentProduct.SayHello();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SayHello_ObjectInitializer()
        {
            //Arrange
            Product currentProduct = new Product()
            {
                ProductName = "Saw",
                ProductId = 1,
                Description = "15-inch steel blade hand saw"
            };

            string expected = "Hello Saw (1): 15-inch steel blade hand saw" + " Available on: ";

            //Act
            string actual = currentProduct.SayHello();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SayHello_NullCheck()
        {
            //Arrange
            Product currentProduct = null;
            string companyName = currentProduct?.ProductVendor?.CompanyName;

            string expected = null;

            //Act
            string actual = companyName;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ConvertMetersToInchesTest()
        {
            // Arrange
            double expected = 78.74;

            // Act
            double actual = 2 * Product.InchesPerMeter;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void MimimumPriceTest_Default()
        {
            // Arrange
            Product currentProduct = new Product();
            decimal expected = .96m;

            // Act
            decimal actual = currentProduct.MinimumPrice;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void MimimumPriceTest_Bulkt()
        {
            // Arrange
            Product currentProduct = new Product(1, "Bulk Tools", "");
            decimal expected = 9.99m;

            // Act
            decimal actual = currentProduct.MinimumPrice;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ProductName_Format()
        {
            // Arrange
            Product currentProduct = new Product();
            currentProduct.ProductName = "  Steel Hammer  ";

            string expected = "Steel Hammer";

            // Act
            string actual = currentProduct.ProductName;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ProductName_FormatNull()
        {
            // Arrange
            Product currentProduct = new Product();

            string expected = null;

            // Act
            string actual = currentProduct.ProductName;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ProductName_TooShort()
        {
            // Arrange
            Product currentProduct = new Product();
            currentProduct.ProductName = "aw";

            string expected = null;
            string expectedMessage = "Product name must be at least 3 characters";

            // Act
            string actual = currentProduct.ProductName;
            string actualMessage = currentProduct.ValidationMessage;

            // Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod()]
        public void ProductName_TooLong()
        {
            // Arrange
            Product currentProduct = new Product();
            currentProduct.ProductName = "Steel Bladed Hand Saw";

            string expected = null;
            string expectedMessage = "Product name cannot be more than 20 characters";

            // Act
            string actual = currentProduct.ProductName;
            string actualMessage = currentProduct.ValidationMessage;

            // Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod()]
        public void ProductName_JustRight()
        {
            // Arrange
            Product currentProduct = new Product();
            currentProduct.ProductName = "Saw";

            string expected = "Saw";
            string expectedMessage = null;

            // Act
            string actual = currentProduct.ProductName;
            string actualMessage = currentProduct.ValidationMessage;

            // Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod()]
        public void Category_DefaultValue()
        {
            // Arrange
            Product currentProduct = new Product();

            string expected = "Tools";

            // Act
            string actual = currentProduct.Category;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Category_NewValue()
        {
            // Arrange
            Product currentProduct = new Product();
            currentProduct.Category = "Hardware";

            string expected = "Hardware";

            // Act
            string actual = currentProduct.Category;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SequenceNumber_DefaultValue()
        {
            // Arrange
            Product currentProduct = new Product();

            int expected = 1;

            // Act
            int actual = currentProduct.SequenceNumber;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SequenceNumber_NewValue()
        {
            // Arrange
            Product currentProduct = new Product();
            currentProduct.SequenceNumber = 5;

            int expected = 5;

            // Act
            int actual = currentProduct.SequenceNumber;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ProductCode_DefaultValue()
        {
            // Arrange
            Product currentProduct = new Product();

            string expected = "Tools-0001";

            // Act
            string actual = currentProduct.ProductCode;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CalculateSuggestedPriceTest()
        {
            // Arrange
            Product currentProduct = new Product(1, "Saw", "");
            currentProduct.Cost = 50m;

            decimal expected = 55m;

            // Act
            decimal actual = currentProduct.CalculateSuggestedPrice(10m);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}