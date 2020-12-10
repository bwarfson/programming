using System;
using Xunit;

namespace fcp_10_recursion
{
    public class RecursionTests
    {
        static long Fib(int n) 
        {
            if (n <= 2)
            {
                return 1;
            }
            return Fib(n - 1) + Fib(n - 2);
        }

        [Fact]
        public void FibTest1()
        {
            var result = Fib(20);

            Assert.Equal(6765, result);
        }
    }
}
