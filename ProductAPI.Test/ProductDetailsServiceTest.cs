using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using ProductAPI.ContextMiddleware;
using ProductAPI.Services;
using ProductAPI.Test.Fixtures;

namespace ProductAPI.Test
{
    public class ProductDetailsServiceTest:IClassFixture<TestFixtures>
    {
        private readonly ProductDBContext _productDBContext;
        private readonly TestFixtures _fixture;

        public ProductDetailsServiceTest(TestFixtures testFixtures)
        {
            var dbContextOptions = new DbContextOptionsBuilder<ProductDBContext>().UseInMemoryDatabase(Guid.NewGuid().ToString().ToString()).Options;
            _productDBContext=new ProductDBContext(dbContextOptions);
            Utils.InitializeForTests(_productDBContext);
            _fixture = testFixtures;
        }

        [Fact]
        public void GetProductList_ReturnsAllProductDetails()
        {
            var mockLogger = new Mock<ILogger<ProductDetailsService>>();
            ProductDetailsService productDetailsService = new ProductDetailsService(_productDBContext, mockLogger.Object);
            var res = productDetailsService.GetProductList().FirstOrDefault();
            res.product_id.Should().Be(1, "Id we are setting as 1 so we are expecting this result");
        }

        [Fact]
        public void AddProductDetails()
        {
            var mockLogger = new Mock<ILogger<ProductDetailsService>>();
            ProductDetailsService productDetailsService = new ProductDetailsService(_productDBContext, mockLogger.Object);
            var res = productDetailsService.SaveProductDetails(_fixture.GetProductDetails(2));
            res.IsSuccess.Should().BeTrue("Inserted Successfully");
        }
    }
}