using Microsoft.EntityFrameworkCore;
using Products.Domain.Entities;

namespace Products.Data
{
    public class ProductsContext : DbContext
    {
        public ProductsContext(DbContextOptions<ProductsContext> opt) : base(opt)
        {
        }

        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<User> User { get; set; }

    }
}
