using pluralsight_dp_strategy.business.models;

namespace pluralsight_dp_strategy.business.strategies.Invoices
{
    public interface IInvoiceStrategy
    {
        public void Generate(Order order);
    }
}