using System;
using GetHired.Core.Authentication.Contracts;
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

        public void Login(string username, string password)
        {
            throw new NotImplementedException();
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