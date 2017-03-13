using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AteraDevProject.DAL
{
    public class DALManager
    {
        public async Task<IEnumerable<Devices>> GetAllDevices()
        {
            try
            {
                var result = await Task.Run(() =>
                {
                    using (AteraDevServerEntities context = new AteraDevServerEntities())
                    {
                        var devices = context.Devices
                            .Include("Owners").ToList();

                        return devices;
                    }
                });

                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine("DALManager.GetAllDevices Failed! Exception: " + e.Message);
                return null;
            }
        }

        public async Task<IEnumerable<Devices>> GetDevicesByOwnerName(string ownerName)
        {
            try
            {
                var result = await Task.Run(() =>
                {
                    using (AteraDevServerEntities context = new AteraDevServerEntities())
                    {
                        var devices = context.Devices
                            .Include("Owners")
                            .Where(device => string.Compare(device.Owners.FullName, ownerName, StringComparison.OrdinalIgnoreCase) == 0)
                            .ToList();

                        return devices;
                    }
                });

                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine("DALManager.GetDevicesByOwnerName Failed! Exception: " + e.Message);
                return null;
            }
        }
    }
}
