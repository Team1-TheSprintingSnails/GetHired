using System;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using GetHired.Core.Authentication.Contracts;
using GetHired.Core.Providers.Contracts;
using GetHired.DataModels.Contracts;

namespace GetHired.Core.Authentication.Providers
{
    public class AuthenticationHadler : IAuthenticationHadler
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IPasswordHashGenerator passwordHashGenerator;

        public AuthenticationHadler(IUnitOfWork unitOfWork, 
            IPasswordHashGenerator passwordHashGenerator)
        {
            this.unitOfWork = unitOfWork;
            this.passwordHashGenerator = passwordHashGenerator;
        }

        public bool Login(string username, string password)
        {
            //var user = this.unitOfWork
            //    .UserRepository.All
            //    .FirstOrDefault(u => u.Username == username);

            //if (user == null)
            //{
            //    return false;
            //}

            //var pass = user.Password;
            //var expectedPasswordHash = pass.PasswordHash;
            //var passwordSalt = pass.PasswordSalt;

            //var actualPasswordHash = this.passwordHashGenerator.GenerateSaltedHash(password, passwordSalt);

            //if (string.Compare(expectedPasswordHash, actualPasswordHash, StringComparison.Ordinal) != 0)
            //{
            //    return false;
            //}

            //var identity = new GenericIdentity(username);
            //Thread.CurrentPrincipal = new GenericPrincipal(identity, new []{user.Role.ToString()});
            return true;
        }

        public void LogOut()
        {
            Thread.CurrentPrincipal = null;
        }

        public bool Register(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}