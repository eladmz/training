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
    /// <summary>
    /// Web API for getting devices.
    /// </summary>
    public class DevicesController : ApiController
    {
        DALManager dal = new DALManager();

        /// <summary>
        /// Get All Devices
        /// </summary>
        /// <returns>Iterative collection of all the devices</returns>
        [HttpGet]
        public async Task<IEnumerable<Devices>> GetAllDevices()
        {
            try
            {
                return await dal.GetAllDevices().ConfigureAwait(false);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("DevicesController.GetAllDevices Failed! Exception: " + ex.Message);
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Get all devices with the provided owner name.
        /// </summary>
        /// <param name="name">Name of the owner</param>
        /// <returns>Iterative collection of all the devices with the owner's name</returns>
        [HttpPost]
        public async Task<IEnumerable<Devices>> GetDevicesByOwnerName([FromBody]string name)
        {
            try
            {
                return await dal.GetDevicesByOwnerName(name).ConfigureAwait(false);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("DevicesController.GetDevicesByOwnerName Failed! Exception: " + ex.Message);
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Get all devices with the provided owner's country.
        /// </summary>
        /// <param name="ownerCountry">Name of the owner's country</param>
        /// <returns>Iterative collection of all the devices from the owner's country</returns>
        [HttpPost]
        public async Task<IEnumerable<Devices>> GetDevicesByOwnerCountry([FromBody]string ownerCountry)
        {
            try
            {
                return await dal.GetDevicesByOwnerCountry(ownerCountry).ConfigureAwait(false);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("DevicesController.GetDevicesByOwnerCountry Failed! Exception: " + ex.Message);
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }
    }
}