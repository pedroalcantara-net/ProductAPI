using Products.Domain.Entities;

namespace Products.Repository.Interface
{
    public interface IProductRepository
    {
        Product Add(Product product);
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetById(int id);
        Product Update(Product product);
        bool Delete(int id);
    }
}