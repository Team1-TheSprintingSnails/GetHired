namespace GetHired.Core.Authentication.Providers
{
    public interface IAuthenticationHadler
    {
        void Login(string username, string password);
        void LogOut();
        void Register();
    }
}