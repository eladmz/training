using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial10
{
    interface IElectronicDevice
    {
        // We want each device to have 
        // these capabilities
        void On();
        void Off();
        void VolumeUp();
        void VolumeDown();
    }
}
