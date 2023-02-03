using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Products.Domain.Entities;
using System.Security.Claims;

namespace Products.Domain
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
