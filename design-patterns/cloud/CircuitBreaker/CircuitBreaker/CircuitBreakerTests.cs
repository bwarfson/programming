using System;
using System.Threading;
using Xunit;

namespace CircuitBreaker
{
    public class CircuitBreakerTests
    {
        private const int MaxFailures = 3;
        private readonly TimeSpan ResetTimeout = TimeSpan.FromMilliseconds(100);
        private readonly TimeSpan Timeout = TimeSpan.FromMilliseconds(100);
        private readonly CircuitBreaker _sut;

        private readonly Action _anyAction = () => { };
        private readonly Action _throwAction = () => { throw new Exception(); };
        private readonly Action _timeoutAction = () => Thread.Sleep(200);

        public CircuitBreakerTests()
        {
            _sut = new CircuitBreaker(Timeout);
        }

         [Fact]
        public void SuccessfulExecution()
        {
            for (var i = 0; i < 100; i++)
            {
                _sut.Execute(_anyAction);
            }
        }

        [Fact]
        public void Failures()
        {
            Assert.Throws<Exception>(() => _sut.Execute(_throwAction));
            Assert.Throws<InvalidOperationException>(() => _sut.Execute(_anyAction));
            Thread.Sleep(200);
            _sut.Execute(_anyAction);
        }

        [Fact]
        public void Test1()
        {
            IProductRepository productRepository = 
                new CircuitBreakerProductRepositoryDecorator(
                    new CircuitBreaker(TimeSpan.FromMinutes(1)),
                    new FakeProductRepository());

            var products = productRepository.GetAll();
        }
    }
}
