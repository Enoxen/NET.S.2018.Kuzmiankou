using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    public static class BinarySearchAlgorithm
    {
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
