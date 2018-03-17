using System.Security.Principal;

namespace GetHired.Core.Authentication.Contracts
{
    public class IdentityProvider : IIdentityProvider
    {
        public IIdentity Identity { get; set; }
    }
}