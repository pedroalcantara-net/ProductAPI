using Products.Domain.Entities;

namespace Products.Service.Interface
{
    public interface IProductService
    {
        Product Add(Product product);
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(int id);
        Product Update(int id, Product product);
        bool Delete(int id);
    }
}