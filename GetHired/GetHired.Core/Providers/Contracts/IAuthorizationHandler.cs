using GetHired.DomainModels.Enums;

namespace GetHired.Core.Providers.Contracts
{
    public interface IAuthorizationHandler
    {
        bool IsAuthorized();
        bool IsAuthorized(Role role);
    }
}