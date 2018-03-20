using System.Threading;
using GetHired.Core.Providers.Contracts;
using GetHired.DomainModels.Enums;

namespace GetHired.Core.Providers
{
    class AuthorizationHandler : IAuthorizationHandler
    {
        public bool IsAuthorized()
        {
            return Thread.CurrentPrincipal != null;
        }

        public bool IsAuthorized(Role role)
        {
            return this.IsAuthorized() && Thread.CurrentPrincipal.IsInRole(role.ToString());
        }
    }
}