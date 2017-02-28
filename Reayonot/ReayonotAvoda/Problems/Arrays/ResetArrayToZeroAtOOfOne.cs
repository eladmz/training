using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReayonotAvoda.Problems.Arrays
{
    class ResetArrayToZeroAtOOfOne
    {
       /**
        * CheckPoint
        * 
        * You are given an array of size n that is started so that all the elements are zero.
        * There exists two methods, get and set s.t they act the same as a normal array.
        * You need to add a functionality of reset s.t after you reset the get returns zero
        * for every slot in the array that wasnt updated before the array.
        * 
        * The answer is to add and additional array of the same length that has a timestamp/ a number
        * indicating if its value was added before\after a global last reset value.
        * if it was added before return zero, else return the value of that element.
        */

        private int[] m_ValueArray;
        private DateTime[] m_DateTimeArray;
        private DateTime m_TimeStamp;

        public ResetArrayToZeroAtOOfOne(int n)
        {
            m_ValueArray = new int[n];
            m_TimeStamp = DateTime.Now;

            for (int i = 0; i < n; i++)
            {
                m_ValueArray[i] = 0;
                m_DateTimeArray[i] = DateTime.Now;
            }
        }

        public void Set(int value, int place)
        {
            if (place > m_ValueArray.Length)
            {
                throw new ArgumentOutOfRangeException();
            }

            m_ValueArray[place] = value;
            m_DateTimeArray[place] = DateTime.Now;
        }

        public int Get(int place)
        {
            if (place > m_ValueArray.Length)
            {
                throw new ArgumentOutOfRangeException();
            }

            return m_TimeStamp > m_DateTimeArray[place] ? 0 : m_ValueArray[place];
        }

        public void Reset()
        {
            m_TimeStamp = DateTime.Now;
        }
    }
}
