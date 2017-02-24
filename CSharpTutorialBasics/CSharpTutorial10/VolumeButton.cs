using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial10
{
    class VolumeButton : ICommand
    {
        // You can refer to instances using
        // the interface
        IElectronicDevice device;

        // Now we get into the specifics of
        // what happens when the power button
        // is pressed.
        public VolumeButton(IElectronicDevice device)
        {
            this.device = device;
        }

        public void Execute()
        {
            device.VolumeUp();
        }

        public void Undo()
        {
            device.VolumeDown();
        }
    }
}
