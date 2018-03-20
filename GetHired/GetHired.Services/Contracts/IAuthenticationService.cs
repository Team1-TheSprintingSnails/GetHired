namespace GetHired.Services.Contracts
{
    public interface IAuthenticationService
    {
        void LogOut();
        bool Login(string username, string password);
        bool Register(string username, string password);
    }
}