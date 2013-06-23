using System.Collections.Generic;
using System.Web.Http;
using RESTWarehouse.Services;
using StoreFront.Domain.Entities;

namespace RESTWarehouse.Controllers
{
    public class ProductsController : ApiController
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        public IList<Product> Get()
        {
            return productService.GetProducts();
        }

        public Product Get(int id)
        {
            return productService.GetProduct(id);
        }
    }
}
