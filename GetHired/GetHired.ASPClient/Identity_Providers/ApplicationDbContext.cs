using Microsoft.AspNet.Identity.EntityFramework;

namespace GetHired.ASPClient.Identity_Providers
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(string connectionString)
            : base(connectionString)
        {
        }

        public ApplicationDbContext()
            : base("name=Identity")
        {
            
        }
    }
}