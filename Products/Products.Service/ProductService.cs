using Products.Domain.Entities;
using Products.Domain.Exceptions;
using Products.Domain.ViewModel;
using Products.Repository.Interface;
using Products.Service.Interface;

namespace Products.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var productList = await _repository.GetProducts();
            return productList.OrderBy(p => p.Name);
        }
        public async Task<Product> GetById(int id)
        {
            var product = await _repository.GetById(id);
            if (product == null) throw new ProductException("Product Does Not Exist");
            return product;
        }
        public Product Add(ProductViewModel product)
        {
            var newProduct = new Product(product.Name, product.Price);
            return _repository.Add(newProduct);
        }
        public Product Update(int id, ProductViewModel product)
        {
            var newProduct = new Product(id, product.Name, product.Price);
            return _repository.Update(newProduct);
        }
        public bool Delete(int id) => _repository.Delete(id);
    }
}
