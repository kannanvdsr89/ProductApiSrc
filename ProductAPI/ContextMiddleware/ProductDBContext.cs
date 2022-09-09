using Microsoft.EntityFrameworkCore;
using ProductAPI.Modules;

namespace ProductAPI.ContextMiddleware
{
    public class ProductDBContext : DbContext
    {
        public ProductDBContext(DbContextOptions<ProductDBContext> options) : base(options) { }
        public DbSet<product_details> product_details { get; set; }
    }
}
