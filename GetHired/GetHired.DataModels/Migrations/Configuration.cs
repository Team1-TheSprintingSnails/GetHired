namespace GetHired.DataModels.Migrations
{
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<GetHired.DataModels.GetHiredContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GetHired.DataModels.GetHiredContext context)
        {
            
        }
    }
}
