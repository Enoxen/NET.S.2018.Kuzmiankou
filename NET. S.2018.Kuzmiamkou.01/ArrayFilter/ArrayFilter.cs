using System;
using System.Collections.Generic;


namespace ArrayFilter
{ 
    /// <summary>
    /// This class provides DigitFilter method that
    /// </summary>
    public class Filter
    {   
        /// <summary>
        /// This method takes an array of integers 
        /// and finds numbers that contain filterNumber
        /// </summary>
        /// <param name="array">Input array.</param>
        /// <param name="filterNumber">Digit to be found.</param>
        /// <returns>List of integer numbers that contain filterNumber</returns>
        public static List<int> DigitFilter(int[] array, int filterNumber)
        {
            var filteredNumbers = new List<int>();
            if(array == null)
            {
                throw new ArgumentNullException("Argument is null");
            }

            foreach(int element in array)
            {
                if (element.ToString().Contains(filterNumber.ToString())){
                    filteredNumbers.Add(element);
                }
            }

            return filteredNumbers;
        }
    }
}
