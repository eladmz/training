using System;


namespace ReayonotAvoda.Problems.Arrays
{
    class SetGetSetAllO1
    {
        /**
        * The task is to create a data structure class such that the method Set, Get, and SetAll
        * take O(1) time
        */
        private ArraySingleSpace m_SetAll;
        private ArraySingleSpace[] m_InternalArray;

        public class ArraySingleSpace
        {
            private int m_Data = 0;
            public DateTime m_LastUpdated;

            public ArraySingleSpace() { }

            public void Set(int i_DataToSet)
            {
                m_Data = i_DataToSet;
                m_LastUpdated = DateTime.Now;
            }

            public int Get()
            {
                return m_Data;
            }
        }

        public SetGetSetAllO1(int i_ArraySize)
        {
            m_InternalArray = new ArraySingleSpace[i_ArraySize];

            for (int i = 0; i < i_ArraySize; i++)
            {
                m_InternalArray[i] = new ArraySingleSpace();
            }

            m_SetAll = new ArraySingleSpace();
        }

        public void SetAll(int m_ValueToSet)
        {
            m_SetAll.Set(m_ValueToSet);
        }

        // TODO: check for exceptions
        public void Set(int i_DataToSet, int i_Index)
        {
            m_InternalArray[i_Index].Set(i_DataToSet);
        }

        /// <summary>
        /// Get the most updated value
        /// If the index was updated after the SetAll command we return its value, otherwise we return the last SetAll value
        /// </summary>
        /// <param name="m_IndexToGet"></param>
        public int Get(int m_IndexToGet)
        {
            return (m_InternalArray[m_IndexToGet].m_LastUpdated > m_SetAll.m_LastUpdated) ? m_InternalArray[m_IndexToGet].Get() : m_SetAll.Get();
        }
    }
}
