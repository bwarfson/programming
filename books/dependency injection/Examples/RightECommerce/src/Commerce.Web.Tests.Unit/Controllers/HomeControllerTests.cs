using System;
using Xunit;

namespace Commerce.Web.Tests.Unit.Controllers
{
    public class HomeControllerTests
    {
        [Fact]
        public void CreateWithNullProductServiceWillThrow()
        {
            // Act
            Action action = () => new HomeController(productService: null);

            // Assert
            Assert.Throws<ArgumentNullException>(action);
        }
    }
}