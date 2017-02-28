using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReayonotAvoda.Problems.Arrays
{
    class StringCompressor
    {
        /**
         * the task is to compress a string in the format: aabcccccaaa --> a2blc5a3.
         * If the string has no compressing, the same string is returned (no added 1's).
         */

        public string CompressStringInPlace(string a)
        {
            if (string.IsNullOrEmpty(a) || a.Length == 1) return a;

            bool flag = false;

            for (int i = 1; i < a.Length; i++)
            {
                if (a.ElementAt(i) == a.ElementAt(i - 1))
                {
                    flag = true;
                    break;
                }
            }

            if (flag) return a;

            string formatedString = "";
            int repeatCounter = 1;

            for (int i = 1; i < a.Length; i++)
            {
                if (a.ElementAt(i) == a.ElementAt(i - 1))
                {
                    repeatCounter++;
                }
                else
                {
                    string.Format("{0}{1}{2}", formatedString, a.ElementAt(i - 1), repeatCounter);
                    repeatCounter = 1;
                }
            }
            string.Format("{0}{1}{2}", formatedString, a.ElementAt(a.Length - 1), repeatCounter);

            return formatedString;
        }
    }
}
