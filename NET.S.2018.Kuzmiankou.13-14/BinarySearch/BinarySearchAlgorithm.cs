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
        #region Public API
        /// <summary>
        /// Generic binary search algorithm implementation.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">Array of objects of type T.</param>
        /// <param name="target">Value to be found.</param>
        /// <param name="comparer">Method for comparison.</param>
        /// <returns>Index of the target object.</returns>
        public static int BinarySearch<T>(T[] array, T target, Comparison<T> comparer)
        {
            ValidateInput(array, target, comparer);

            bool found = false;
            int first = 0, last = array.Length - 1, mid = 0;

            while (!found && first <= last)
            {
                mid = (first + last) / 2;

                if (comparer(target, array[mid])  == -1)
                {
                    last = mid - 1;
                }

                if (comparer(target, array[mid]) == 1)
                {
                    first = mid + 1;
                }

                if (comparer(target, array[mid]) == 0)
                {
                    found = true;
                }
            }
            return mid;
        }

        /// <summary>
        /// Generic binary search algorithm implementation.
        /// </summary>
        /// <typeparam name="T">Type param that implements IComparable</typeparam>
        /// <param name="array">Array of objects of type T.</param>
        /// <param name="target">Value to be found.</param>
        /// <param name="comparer">Object for comparison</param>
        /// <returns>Index of the target object.</returns>
        public static int BinarySearch<T>(T[] array, T target, IComparer<T> comparer)
        {
            ValidateInput(array, target, comparer);

            bool found = false;
            int first = 0, last = array.Length - 1, mid = 0;

            while (!found && first <= last)
            {
                mid = (first + last) / 2;

                if (comparer.Compare(target, array[mid]) == -1)
                {
                    last = mid - 1;
                }

                if (comparer.Compare(target, array[mid]) == 1)
                {
                    first = mid + 1;
                }

                if (comparer.Compare(target, array[mid]) == 0)
                {
                    found = true;
                }
            }
            return mid;
        }

        #endregion

        #region Validation of input

        /// <summary>
        /// Validates input parameters and throws exceptions if they are valid.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">Array of elements.</param>
        /// <param name="target">Value to be found.</param>
        /// <param name="comparer">Comparison delegate.</param>
        private static void ValidateInput<T>(T[] array, T target, Comparison<T> comparer)
        {
            ValidateCommon(array, target);

            if (comparer is null)
            {
                throw new ArgumentNullException(nameof(target));
            }
        }

        /// <summary>
        /// Validates input parameters and throws exceptions if they are valid.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">Array of elements.</param>
        /// <param name="target">Value to be found.</param>
        /// <param name="comparer">Comparison object.</param>
        private static void ValidateInput<T>(T[] array, T target, IComparer<T> comparer)
        {
            ValidateCommon(array, target);

            if (comparer is null)
            {
                throw new ArgumentNullException(nameof(target));
            }
        }

        /// <summary>
        /// Validates input parameters and throws exceptions if they are not valid.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">Array of elements.</param>
        /// <param name="target">Value to be found.</param>
        private static void ValidateCommon<T>(T[] array, T target)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (ReferenceEquals(target, null))
            {
                throw new ArgumentNullException(nameof(target));
            }
        }
        #endregion
    }
}
