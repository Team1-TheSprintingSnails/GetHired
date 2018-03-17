using System.Security.Principal;

namespace GetHired.Core.Authentication.Contracts
{
    public interface IIdentityProvider
    {
        IIdentity Identity { get; set; }
    }
}