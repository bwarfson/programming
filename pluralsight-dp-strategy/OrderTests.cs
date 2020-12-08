using System;
using Xunit;
using Xunit.Abstractions;
using pluralsight_dp_strategy.business.models;


namespace pluralsight_dp_strategy
{
    public class OrderTests
    {
        private readonly ITestOutputHelper output;

        public OrderTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void Test1()
        {
            var orders = new[] {
                new Order
                {
                    ShippingDetails = new ShippingDetails
                    {
                        OriginCountry = "Sweden"
                    }
                },
                new Order
                {
                    ShippingDetails = new ShippingDetails
                    {
                        OriginCountry = "USA"
                    }
                },
                new Order
                {
                    ShippingDetails = new ShippingDetails
                    {
                        OriginCountry = "Sweden"
                    }
                },
                new Order
                {
                    ShippingDetails = new ShippingDetails
                    {
                        OriginCountry = "USA"
                    }
                },
                new Order
                {
                    ShippingDetails = new ShippingDetails
                    {
                        OriginCountry = "Singapore"
                    }
                }
            };

        }
    }
}
