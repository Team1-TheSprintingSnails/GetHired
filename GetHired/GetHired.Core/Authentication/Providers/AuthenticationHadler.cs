using System;
using GetHired.Core.Authentication.Contracts;
using GetHired.DataModels.Contracts;

namespace GetHired.Core.Authentication.Providers
{
    public class AuthenticationHadler : IAuthenticationHadler
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IIdentityProvider idednProvider;

        public AuthenticationHadler(IUnitOfWork unitOfWork, IIdentityProvider idednProvider)
        {
            this.unitOfWork = unitOfWork;
            this.idednProvider = idednProvider;
        }

        public void Login(string username, string password)
        {
            
        }

        public void LogOut()
        {
            throw new NotImplementedException();
        }

        public void Register()
        {
            throw new NotImplementedException();
        }
    }
}