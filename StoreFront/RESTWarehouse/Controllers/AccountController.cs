using System.Web.Http;
using RESTWarehouse.Services;

namespace RESTWarehouse.Controllers
{
    public class AccountController : ApiController
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }
        [HttpGet]
        public bool Login(string username, string passwordhash)
        {
            return accountService.Login(username, passwordhash);
        }
       
    }
}