using GetHired.DomainModels.Enums;

namespace GetHired.Core.Authentication.Contracts
{
    public interface IAuthorizationHandler
    {
        bool IsAuthorized();
        bool IsAuthorized(Role role);
    }
}