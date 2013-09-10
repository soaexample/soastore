using System.Collections.Generic;
using RestSharp;
using StoreFront.Domain.Entities;

namespace StoreFront.Services
{
    public interface IAccountService
    {
        bool Login(string userName, string password);
    }

    public class AccountService : IAccountService
    {
        public bool Login(string userName, string password)
        {
            var client = new RestClient("http://localhost:4874");
        
            var request = new RestRequest("api/Account/Login", Method.GET);
            request.AddParameter("username", userName); // adds to POST or URL querystring based on Method
            request.AddParameter("passwordhash", password); // adds to POST or URL querystring based on Method
            
            //  request.AddUrlSegment("id", 123); // replaces matching token in request.Resource

            // easily add HTTP Headers
            //     request.AddHeader("header", "value");


            // execute the request

          //  IRestResponse<string> response = client.Execute<string>(request);
            var restResponse = client.Execute(request);

            

            return true;
         //   return response.Data;
        }
    }
}