using System;


namespace Sorting
{
    /// <summary>
    /// This class provides two sorting methods:
    /// QuickSort and MergeSort.
    /// </summary>
    public class Sort
    {   
        /// <summary>
        /// Quick sort algorithm implementation.
        /// </summary>
        /// <param name="array">Array to be sorted.</param>
        /// <param name="start">Start index of array</param>
        /// <param name="end">End index of array.</param>
        public static void QuickSort(int[] array, int start, int end)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Array is null");
            }

            if (start < end)
            {
                int pivot = Partition(array, start, end);
                QuickSort(array, start, pivot - 1);
                QuickSort(array, pivot + 1, end);
            }
        }

        /// <summary>
        ///Merge sort algorithm implementation
        /// </summary>
        /// <param name="array">Array to be sorted</param>
        /// <param name="start">Array start index</param>
        /// <param name="end">Array end index</param>
        public static void MergeSort(int[] array, int start, int end)
        {
           
            if (end > start)
            {
                int mid = (end + start) / 2;
                MergeSort(array, start, mid);
                MergeSort(array, (mid + 1), end);
                DoMerge(array, start, (mid + 1), end);
            }
        }

        /// <summary>
        /// Array partition for quick sort.
        /// </summary>
        /// <param name="array">Array to be sorted.</param>
        /// <param name="start">Start index of array.</param>
        /// <param name="end">End index of array.</param>
        /// <returns>Returns pivot index</returns>
        private static int Partition(int[] array, int start, int end)
        {
            int temp;
            int marker = start;
            for (int i = start; i <= end; i++)
            {
                if (array[i] < array[end])
                {
                    temp = array[marker];
                    array[marker] = array[i];
                    array[i] = temp;
                    marker += 1;
                }
            }

            temp = array[marker];
            array[marker] = array[end];
            array[end] = temp;
            return marker;
        }



        /// <summary>
        /// Merge sort algorithm implementation.
        /// </summary>
        /// <param name="array">Array to be sorted</param>
        /// <param name="start">Start index of array</param>
        /// <param name="end">End index of array</param>
        /// <param name="mid">Middle index for merge function</param>
        private static void DoMerge(int[] array, int start, int mid, int end)
        {
            int[] temp = new int[end + 1];
            int i;
            int leftEnd = (mid - 1);
            int tmpPos = start;
            int numElements = (end - start + 1);

            while ((start <= leftEnd) && (mid <= end))
            {
                if (array[start] <= array[mid])
                {
                    temp[tmpPos++] = array[start++];
                }

                else
                {
                    temp[tmpPos++] = array[mid++];
                }

            }

            while (start <= leftEnd)
            {
                temp[tmpPos++] = array[start++];
            }

            while (mid <= end)
            {
                temp[tmpPos++] = array[mid++];
            }

            for (i = 0; i < numElements; i++)
            {         
                array[end] = temp[end];
                end--;           
            }
        }
    }
}
