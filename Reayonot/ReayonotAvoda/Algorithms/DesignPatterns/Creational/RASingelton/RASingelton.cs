using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReayonotAvoda.Problems.DataStructures
{
    public class RASingelton
    {
        private static RASingelton singeltonInstance;

        protected RASingelton()
        {
        }

        public static RASingelton GetSingelton()
        {
            return singeltonInstance ?? (singeltonInstance = new RASingelton());
        }
    }
}
