using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sorting;

namespace Sorting.Test
{
    /// <summary>
    /// This class provides tests for Sorting class
    /// </summary>
    [TestClass]
    public class SortTests
    {

        [TestMethod]
        public void QuickSort_Test_15_2_n4_5_6_Sort()
        {
            // arrange
            int[] array = new int[] { 15, 2, -4, 5, 6 };

            // act
            Sort.QuickSort(array, 0, array.Length - 1);
                    
            // assert
            CollectionAssert.AreEqual(new int[] { -4, 2, 5, 6, 15 }, array);
        }

        [TestMethod]
        public void QuickSort_Test_1_2_3_4_5_6_Sort()
        {
            // arrange
            int[] array = new int[] { 1, 2, 3, 4, 5, 6 };

            // act
            Sort.QuickSort(array, 0, array.Length - 1);

            // assert
            CollectionAssert.AreEqual(new int[] { 1, 2, 3, 4, 5, 6 }, array);
        }

        [TestMethod]
        public void QuickSort_Test_Null()
        {
            // arrange
            int[] array = null;

            // assert
            Assert.ThrowsException<ArgumentNullException>(() => Sort.QuickSort(array, 0, 0));
        }

        [TestMethod]
        public void QuickSort_15_2_2_4_8_4_5_15_Sort()
        {
            // arrange
            int[] array = new int[] { 15, 2, 2, 4, 8, 4, 5, 15 };

            // act
            Sort.QuickSort(array, 0, array.Length - 1);

            // assert
            CollectionAssert.AreEqual(new int[] { 2, 2, 4, 4, 5, 8, 15, 15 }, array);
        }

        [TestMethod]
        public void MergeSort_Test_15_2_n4_5_6_Sort()
        {
            // arrange
            int[] array = new int[] { 15, 2, -4, 5, 6 };

            // act
            Sort.MergeSort(array, 0, array.Length - 1);

            // assert
            CollectionAssert.AreEqual(new int[] { -4, 2, 5, 6, 15 }, array);
        }

        [TestMethod]
        public void MergeSort_Test_1_2_3_4_5_6_Sort()
        {
            // arrange
            int[] array = new int[] { 1, 2, 3, 4, 5, 6 };

            // act
            Sort.MergeSort(array, 0, array.Length - 1);

            // assert
            CollectionAssert.AreEqual(new int[] { 1, 2, 3, 4, 5, 6 }, array);
        }

        [TestMethod]
        public void MergeSort_15_2_2_4_8_4_5_15_Sort()
        {
            // arrange
            int[] array = new int[] { 15, 2, 2, 4, 8, 4, 5, 15 };

            // act
            Sort.MergeSort(array, 0, array.Length - 1);

            // assert
            CollectionAssert.AreEqual(new int[] { 2, 2, 4, 4, 5, 8, 15, 15 }, array);
        }
    }
}
