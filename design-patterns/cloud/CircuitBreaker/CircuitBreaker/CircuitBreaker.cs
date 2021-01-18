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
        public int Failures { get; private set; }
        public int Threshold { get; private set; }        
        public ICircuitState State { get; private set; }
        public CircuitBreaker(TimeSpan timeout, int threshold)
        {
            this.State = new ClosedCircuitState(timeout);
            this.Threshold = threshold;
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

        internal void IncreaseFailureCount()
        {
            Failures++;
        }
 
        internal void ResetFailureCount()
        {
            Failures = 0;
        }
        public bool IsThresholdReached()
        {
            return Failures >= Threshold;
        }
    }
}