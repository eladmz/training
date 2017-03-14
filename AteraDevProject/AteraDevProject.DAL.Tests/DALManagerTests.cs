using Microsoft.VisualStudio.TestTools.UnitTesting;
using AteraDevProject.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AteraDevProject.DAL.Tests
{
    [TestClass()]
    public class DALManagerTests
    {
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GenerateDeviceUniqueNameTest_Null()
        {
            // arrange
            Devices device = null;

            // Act
            var actual = DALManager.GenerateDeviceUniqueName(device);

            // Assert - Exception thrown
        }

        [TestMethod()]
        public void GenerateDeviceUniqueNameTest()
        {
            // arrange
            var device = new Devices()
            {
                DeviceId = 1,
                Name = "Test",
                Created = new DateTime(1999, 12, 25, 12, 53, 00),
                OwnerId = 123456
            };

            var expected = "1_Test_25/12/1999 12:53:00_123456";

            // Act
            var actual = DALManager.GenerateDeviceUniqueName(device);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DaysSinceDeviceWasCreatedTest_Null()
        {
            // arrange
            Devices device = null;

            // Act
            var actual = DALManager.DaysSinceDeviceWasCreated(device);

            // Assert - Exception thrown
        }

        [TestMethod()]
        public void DaysSinceDeviceWasCreatedTest()
        {
            // arrange
            var daysDifference = 52;
            var device = new Devices()
            {
                DeviceId = 1,
                Name = "Test",
                Created = DateTime.Now.AddDays(-daysDifference),
                OwnerId = 123456
            };

            var expected = daysDifference;

            // Act
            var actual = DALManager.DaysSinceDeviceWasCreated(device);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}