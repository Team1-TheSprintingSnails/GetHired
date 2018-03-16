using System.Threading;
using GetHired.Core.Authentication.Attributes;
using GetHired.DataModels.Contracts;

namespace GetHired.Core.Authentication.Providers
{
    public class AuthenticationHadler : IAuthenticationHadler
    {
        private readonly IUnitOfWork unitOfWork;

        public AuthenticationHadler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [LogoutRequired]
        public void Login(string username, string password)
        {
            
        }

        [LoginRequired]
        public void LogOut()
        {
            Thread.CurrentPrincipal = null;
        }

        [LogoutRequired]
        public void Register()
        {
            
        }
    }
}