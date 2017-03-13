using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AteraDevProject.DAL
{
    public class DALManager
    {
        public IEnumerable<Devices> GetAllDevices()
        {
            using (AteraDevServerEntities context = new AteraDevServerEntities())
            {
                var devices = context.Devices
                    .Include("Owners").ToList();

                return devices;
            }
        }

        public IEnumerable<Devices> GetDevicesByOwnerName(string ownerName)
        {
            using (AteraDevServerEntities context = new AteraDevServerEntities())
            {
                var devices = context.Devices.Where(device => device.Owners.FullName == ownerName).ToList();

                return devices;
            }
        }
    }
}
