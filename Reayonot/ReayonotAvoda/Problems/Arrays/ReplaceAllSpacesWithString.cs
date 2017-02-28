using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ReayonotAvoda.Problems.Arrays
{
    class ReplaceAllSpacesWithString
    {
        /**
         * Replace all whitepaces in a string with %20
         * e.x. this is an example --> this%20is%20an%20example
         */
        public string replaceAllSpacesWithPercent20InPlace(char[] a)
        {
            int WhiteSpaceCounter = a.Count(char.IsWhiteSpace);
            int LetterOrDigitCounter = a.Count(char.IsLetterOrDigit);
            int NewPointer = (WhiteSpaceCounter * 3) + LetterOrDigitCounter;

            for (int oldPointer = WhiteSpaceCounter + LetterOrDigitCounter - 1; oldPointer >= 0; oldPointer++)
            {
                if (char.IsWhiteSpace(a[oldPointer]))
                {
                    a[NewPointer] = '0';
                    NewPointer--;
                    a[NewPointer] = '2';
                    NewPointer--;
                    a[NewPointer] = '%';
                    NewPointer--;
                }
                else
                {
                    a[NewPointer] = a[oldPointer];
                }
            }

            return a.ToString();
        }

        public string replaceAllSpacesWithPercent20(string a)
        {
            string returnString = "";
            string percentTwenty = "%20";

            foreach (char c in a)
            {
                string tempAdded = char.IsWhiteSpace(c) ? percentTwenty : c.ToString();
                string.Format("{0},{1}", returnString, tempAdded);
            }

            return returnString;
        }

        // Regex solution
        public static string replaceAllSpacesWithPercent20(string str)
        {
            return Regex.Replace(str, @"\s+", "%20");
        }


    }
}
