using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GetHired.ASPClient.Identity_Providers
{
    public class ApplicationUserStore : UserStore<ApplicationUser>, IUserStore<ApplicationUser>
    {
        public ApplicationUserStore(ApplicationDbContext context)
            : base(context)
        {
            
        }
    }
}