using pluralsight_dp_strategy.business.models;

namespace pluralsight_dp_strategy.business.strategies.SalesTax
{
    public interface ISalesTaxStrategy
    {
        public decimal GetTaxFor(Order order);
    }
}