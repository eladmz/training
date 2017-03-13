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
    public class DBManagerTests
    {
        [TestMethod()]
        public void GetAllDevicesTest()
        {
            var dal = new DBManager();
            var result = dal.GetAllDevices();


            Assert.Fail();
        }
    }
}