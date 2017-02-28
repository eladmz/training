using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;


namespace ReayonotAvoda.DataSets.DataStructures.RASingelton
{
    /*
     * Optimove
     */
    public class ThreadsafeSingelton
    {
        private static ThreadsafeSingelton SingletoneInstance;

        protected ThreadsafeSingelton()
        {
            
        }

        public static ThreadsafeSingelton GetSingelton()
        {
            if (SingletoneInstance == null)
            {
                lock (SingletoneInstance)
                {
                    if (SingletoneInstance == null)
                    {
                        SingletoneInstance = new ThreadsafeSingelton();
                    }
                }
            }

            return SingletoneInstance;
        }
    }
}
