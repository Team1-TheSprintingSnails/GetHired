using GetHired.DataModels.Models;

namespace GetHired.DataModels.Migrations
{
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<GetHiredContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GetHiredContext context)
        {
            
        }
    }
}
