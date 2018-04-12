using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    /// <summary>
    /// Generic binary search algorithm.
    /// </summary>
    public static class BinarySearchAlgorithm
    {
        /// <summary>
        /// Generic binary search algorithm implementation.
        /// </summary>
        /// <typeparam name="T">Type param that implements IComparable</typeparam>
        /// <param name="array">Array of objects of type T.</param>
        /// <param name="target">Value to be found.</param>
        /// <returns>Index of the target object.</returns>
        public static int BinarySearch<T>(T[] array, T target) where T: System.IComparable<T>
        {
            bool found = false;
            int first = 0, last = array.Length - 1, mid = 0;

            while (!found && first <= last)
            {
                mid = (first + last) / 2;

                if (target.CompareTo(array[mid])  == -1)
                {
                    last = mid - 1;
                }

                if (target.CompareTo(array[mid]) == 1)
                {
                    first = mid + 1;
                }

                if (target.CompareTo(array[mid]) == 0)
                {
                    found = true;
                }
            }
            return mid;
        }
    }
}
