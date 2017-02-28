using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ReayonotAvoda.Problems.Arrays
{
    /**
     * Some startup
     * 
     * Given two strings check if they are anagrams of each other
     * Given a list of strings sort them into sub arrays of anagrams
     * 
     * using o(n) time o(256) space we can go over the arrays and using an additional array to count the number
     * of recurring characters in ascii format
     * 
     * additional methods include sorting the arrays and comparing the sorted arrays at o(2nlogn) time o(1) space
     */
    class Anagrams
    {
        //in case all the characters are ascii and uper\lower case dont matter we can check with an ascii array
        public bool isAnagram(string a, string b)
        {
            if (a.Length != b.Length)
            {
                return false;
            }

            a = a.ToLower();
            b = b.ToLower();

            int[] letterCounter = new int[256];

            foreach (char c in a)
            {
                letterCounter[c]++;
            }
            foreach (char c in b)
            {
                letterCounter[c]--;
            }
            return letterCounter.All(i => i == 0);
        }
    }
}
