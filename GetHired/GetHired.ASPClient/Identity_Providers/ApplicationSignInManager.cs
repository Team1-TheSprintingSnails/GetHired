using System.Security.Claims;
using System.Threading.Tasks;
using GetHired.ASPClient.Identity_Providers;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace IdentityDemoWithIoC
{
    public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
        }
    }
}