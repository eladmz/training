using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial10
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a Vehicle object
            Vehicle buick = new Vehicle("Buick", 4, 160);

            // Check if Vehicle implements 
            // IDrivable
            if (buick is IDrivable)
            {
                buick.Move();
                buick.Stop();
            }
            else
            {
                Console.WriteLine("The {0} can't be driven", buick.Brand);
            }

            // We are now modeling the act of
            // picking up a remote, aiming it
            // at the TV, clicking the power
            // button and then watching as
            // the TV turns on and off

            // Pick up the TV remote
            IElectronicDevice TV = TVRemote.GetDevice();

            // Create the power button
            PowerButton powBut = new PowerButton(TV);

            // Turn the TV on and off with each 
            // press
            powBut.Execute();

            VolumeButton volBut = new VolumeButton(TV);

            volBut.Execute();
            volBut.Execute();
            volBut.Execute();
            volBut.Execute();
            volBut.Undo();
            volBut.Undo();
            volBut.Execute();
            volBut.Undo();
            volBut.Undo();
            volBut.Undo();
            volBut.Undo();
            volBut.Undo();
            volBut.Undo();

            powBut.Undo();

            Console.ReadLine();
        }
    }
}
