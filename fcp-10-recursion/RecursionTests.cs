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

        static decimal Factorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            else
            {
                return n * Factorial(n - 1);
            }
        }

        [Fact]
        public void FibTest1()
        {
            var result = Fib(20);

            Assert.Equal(6765, result);
        }

        [Fact]
        public void FactorialTest1()
        {
            var result = Factorial(1);

            Assert.Equal(1, result);
        }

        [Fact]
        public void FactorialTest2()
        {
            var result = Factorial(5);

            Assert.Equal(120, result);
        }
    }
}
