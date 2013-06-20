using System;
using System.Collections;
using System.Collections.Generic;
using DotNetOpenAuth.OpenId.Extensions.AttributeExchange;
using RestSharp;
using StoreFront.Domain.Entities;

namespace StoreFront.Services
{
    public interface IProductService
    {
        IList<Product> GetProducts();
    }

    public class ProductService : IProductService
    {
        public IList<Product> GetProducts()
        {
            var client = new RestClient("http://localhost:4874");
            // client.Authenticator = new HttpBasicAuthenticator(username, password);

            var request = new RestRequest("api/Products", Method.GET);
          //  request.AddParameter("name", "value"); // adds to POST or URL querystring based on Method
          //  request.AddUrlSegment("id", 123); // replaces matching token in request.Resource

            // easily add HTTP Headers
       //     request.AddHeader("header", "value");

         
            // execute the request
             
            IRestResponse<List<Product>> response = client.Execute<List<Product>>(request);

            return response.Data;

        }
    }
}