using algorithms;
using System;
using Xunit;

namespace algorithms_tests
{
    public class mergeSortTests
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
