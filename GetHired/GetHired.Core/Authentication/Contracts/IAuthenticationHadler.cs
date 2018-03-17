namespace GetHired.Core.Authentication.Contracts
{
    public interface IAuthenticationHadler
    {
        void Login(string username, string password);
        void LogOut();
        void Register();
    }
}