namespace RESTWarehouse.Services
{
    public interface IAccountService
    {
        bool Login(string username, string passwordhash);
    }

    public class AccountService : IAccountService
    {
        public bool Login(string username, string passwordhash)
        {
            return true;
        }
    }
}