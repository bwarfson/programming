using System;
using Xunit;

namespace mergesort
{
    public class MergeSortTests
    {
        [Fact]
        public void Test1()
        {
            var sortAlgorithm = new IntMergeSort();

            var testArray = new int[] { 8, 6, 7, 5, 3, 0, 9 };

            var sorted = sortAlgorithm.MergeSort(testArray, 0, testArray.Length - 1);
        }
    }
}
