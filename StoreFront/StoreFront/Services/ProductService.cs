using System.Collections.Generic;
using RestSharp;
using StoreFront.Domain.Entities;

namespace StoreFront.Services
{
    public interface IProductService
    {
        IList<Product> GetProducts();
        Product GetProductById(int id);
    }

    public class ProductService : IProductService
    {
        private RestClient GetClient()
        {
            var client = new RestClient("http://localhost:8001");
            //necessary initialization

            return client;
        }
        public IList<Product> GetProducts()
        {
            var client = GetClient();

            var request = new RestRequest("api/Products/Get", Method.GET);
             
            IRestResponse<List<Product>> response = client.Execute<List<Product>>(request);

            return response.Data;
        }

        public Product GetProductById(int id)
        {
            var client = GetClient();

            var request = new RestRequest("api/Products/GetProductById", Method.GET);
            request.AddParameter("id", id); 
       

            IRestResponse<Product> response = client.Execute<Product>(request);

            return response.Data;
        }
    }
}