using AteraDevProject.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AteraDevProject.Web
{
    public class DevicesController : ApiController
    {
        DALManager dal = new DALManager();

        [HttpGet]
        public async Task<ICollection<Devices>> GetAllDevices()
        {
            try
            {
                return await dal.GetAllDevices().ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Console.WriteLine("DevicesController.GetAllDevices Failed! Exception: " + e.Message);
                Console.WriteLine(e.StackTrace);
                return null;
            }
        }

        [HttpPost]
        public async Task<IEnumerable<Devices>> GetDevicesByOwnerName([FromBody]string name)
        {
            try
            {
                return await dal.GetDevicesByOwnerName(name).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Console.WriteLine("DevicesController.GetDevicesByOwnerName Failed! Exception: " + e.Message);
                Console.WriteLine(e.StackTrace);
                return null;
            }
        }
    }
}