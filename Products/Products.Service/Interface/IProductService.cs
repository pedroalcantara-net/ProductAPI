using Products.Domain.Entities;
using Products.Domain.ViewModel;

namespace Products.Service.Interface
{
    public interface IProductService
    {
        Product Add(ProductViewModel product);
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetById(int id);
        Product Update(int id, ProductViewModel product);
        bool Delete(int id);
    }
}