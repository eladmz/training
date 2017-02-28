using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReayonotAvoda.Problems.Arrays
{
    /*
     * Optimove
     * 
     * The question was to return the most recurring element in a provided array
     * 
     * The answer was to use an external dictionary to count the amount of apearances of the element
     * and keep an addiitonal element that holds the largest element in the dictionary, an extension
     * can be added that if elements are taken out of the dictionary it makes a check if that element
     * is still the largest element in the dictionary, if it is then it updates the largest count,
     * else it goes over the dictionary to find the new largest element.
     */
    class GetMostReacuringElement<T>
    {
        public GetMostReacuringElement()
        {
            
        }

        public T GetMostRecurringElement(T[] TArray)
        {
            if (TArray == null || TArray.Length == 0)
            {
                throw new ArgumentNullException("TArray null or empty");
            }
            if (TArray.Length == 1)
            {
                return TArray[0];
            }

            Dictionary<T, int> Tdictionary = new Dictionary<T, int>();
            T mostReacurring = TArray[0];

            foreach (T element in TArray)
            {
                if (Tdictionary.ContainsKey(element))
                {
                    Tdictionary[element]++;

                    if (Tdictionary[element] > Tdictionary[mostReacurring])
                    {
                        mostReacurring = element;
                    }
                }
                else
                {
                    Tdictionary.Add(element, 1);
                }
            }

            return mostReacurring;
        }
    }
}
