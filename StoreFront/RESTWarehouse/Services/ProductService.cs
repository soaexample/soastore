using System.Collections.Generic;
using System.Linq;
using Raven.Client;
using StoreFront.Domain.Entities;

namespace RESTWarehouse.Services
{
    public class ProductService : IProductService
    {
        private readonly IDocumentSession session;

        public ProductService(IDocumentSession session)
        {
            this.session = session;
        }

        public IList<Product> GetProducts()
        {
            var products = session.Query<Product>().ToList();
            return products;
        }

        public Product GetProduct(int id)
        {
            return session.Load<Product>(id);
        }
    }

    public interface IProductService
    {
        IList<Product> GetProducts();
        Product GetProduct(int id);
    }
}