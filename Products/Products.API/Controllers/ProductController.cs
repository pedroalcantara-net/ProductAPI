using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Products.Domain.Entities;
using Products.Domain.Exceptions;
using Products.Service.Interface;
using System.Net;

namespace Products.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _product;
        public ProductController(IProductService product)
        {
            _product = product;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts() => Ok(await _product.GetAll());

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetProductById([FromRoute] int id) => Ok(await _product.GetById(id));

        [HttpPost]
        public ActionResult<Product> AddProducts([FromBody] Product product) => Created("", _product.Add(product));

        [HttpPut("{id:int}")]
        public ActionResult<Product> UpdateProduct([FromBody] Product product, [FromRoute] int id) => Created("", _product.Update(id, product));

        [HttpDelete("{id:int}")]
        public ActionResult<bool> DeleteProductById([FromRoute] int id) => Ok(_product.Delete(id));
    }
}
