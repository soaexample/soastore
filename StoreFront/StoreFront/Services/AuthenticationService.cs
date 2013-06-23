namespace StoreFront.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public void CreateUserAndAccount(string username, string password)
        {
            
        }

        public void Login(string username, string password)
        {
            
        }
    }

    public interface IAuthenticationService
    {
        void CreateUserAndAccount(string username, string password);
        void Login(string username, string password);

    }
}