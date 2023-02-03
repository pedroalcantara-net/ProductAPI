using Microsoft.EntityFrameworkCore;
using Products.Data;
using Products.Domain.Entities;
using Products.Repository.Interface;

namespace Products.Repository
{
    public class ProductRepository : IProductRepository
    {
        protected readonly ProductsContext _context;
        protected readonly DbSet<Product> _product;

        public ProductRepository(ProductsContext context)
        {
            _context = context;
            _product = context.Set<Product>();
        }

        public async Task<IEnumerable<Product>> GetProducts() => await _product.ToListAsync();
        public async Task<Product> GetById(int id) => await _product.FindAsync(id);
        public Product Add(Product product)
        {
            _product.Add(product);
            _context.SaveChanges();
            return product;
        }
        public Product Update(Product product)
        {
            _product.Update(product);
            _context.SaveChanges();
            return product;
        }

        public bool Delete(int id)
        {
            var product = _product.Find(id);
            if (product == null) return false;
            _product.Remove(product);
            _context.SaveChanges();
            return true;
        }
    }
}
