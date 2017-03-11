using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softimize
{
    public class CollectionChangedEventArgs : EventArgs
    {
        public string Message { get; }

        public CollectionChangedEventArgs(string message)
        {
            Message = message;
        }
    }
}
