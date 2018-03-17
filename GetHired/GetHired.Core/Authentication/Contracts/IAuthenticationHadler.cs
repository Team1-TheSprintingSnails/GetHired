namespace GetHired.Core.Authentication.Contracts
{
    public interface IAuthenticationHadler
    {
        void LogOut();
        bool Login(string username, string password);
        bool Register(string username, string password);
    }
}