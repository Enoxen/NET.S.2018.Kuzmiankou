using System;
using System.Collections.Generic;
using NUnit.Framework;
using ArrayFilter;
using NUnit.Framework.Internal;

namespace ArrayFilterTest
{
    /// <summary>
    ///This class provides tests for ArrayFilter class and it's 
    ///DigitFilter method.
    /// </summary>
    [TestFixture]
    public class FilterDigitTest
    {
        [Test]
        [TestCase(new int[] {11, 12, 14, 5, 1, 6, 61}, 1, new int[] {11, 12, 14, 1, 61})]
        [TestCase(new int[] {11, 12, 14, 5, 1, 6, 61}, 2, new int[] {12})]
        [TestCase(new int[] {11, 12, 14, 5, 1, 6, 61}, 6, new int[] {6, 61})]
        public void FilterDigitTests(int[] array, int num, int[] result)
        {
            CollectionAssert.AreEquivalent(Filter.DigitFilter(array, num), result);
        }
    }
}
