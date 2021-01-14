using System;

namespace CircuitBreaker
{
    public interface ICircuitState
    {
        ICircuitState NextState();
        void Guard();
        void Succeed();
        void Trip(Exception e);
    }
    
    public interface ICircuitBreaker
    {
        void Guard();
        void Succeed();
        void Trip(Exception exception);
    }
    public class CircuitBreaker : ICircuitBreaker
    {
        public ICircuitState State { get; private set; }
        public CircuitBreaker(TimeSpan timeout)
        {
            this.State = new ClosedCircuitState(timeout);
        }

        public void Guard()
        {
            this.State = this.State.NextState();
            this.State.Guard();
            this.State = this.State.NextState();
        }

        public void Trip(Exception exception)
        {
            this.State = this.State.NextState();
            this.State.Trip(exception);
            this.State = this.State.NextState();
        }

        public void Succeed()
        {
            this.State = this.State.NextState();
            this.State.Succeed();
            this.State = this.State.NextState();
        }
    }
}