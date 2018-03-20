using System;
using System.Threading;
using GetHired.DataModels.Contracts;
using GetHired.Services.Contracts;

namespace GetHired.Services.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IPasswordHashGenerator passwordHashGenerator;

        public AuthenticationService(IUnitOfWork unitOfWork, 
            IPasswordHashGenerator passwordHashGenerator)
        {
            this.unitOfWork = unitOfWork;
            this.passwordHashGenerator = passwordHashGenerator;
        }

        public bool Login(string username, string password)
        {
        //    var user = this.unitOfWork
        //        .UserRepository.All
        //        .FirstOrDefault(u => u.Username == username);

        //    if (user == null)
        //    {
        //        return false;
        //    }

        //    var pass = user.Password;
        //    var expectedPasswordHash = pass.PasswordHash;
        //    var passwordSalt = pass.PasswordSalt;

        //    var actualPasswordHash = this.passwordHashGenerator.GenerateSaltedHash(password, passwordSalt);

        //    if (string.Compare(expectedPasswordHash, actualPasswordHash, StringComparison.Ordinal) != 0)
        //    {
        //        return false;
        //    }

        //    var identity = new GenericIdentity(username);
        //    Thread.CurrentPrincipal = new GenericPrincipal(identity, new[] { user.Role.ToString() });
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