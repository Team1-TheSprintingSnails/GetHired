using GetHired.DataModels.Models;
using GetHired.DomainModels;

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
            //User[] users = new User[]
            //{
            //    new User()
            //    {

            //    }, 
            //};
            //context.Users.AddOrUpdate(users);
        }
    }
}
