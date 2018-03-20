using System.Data.Entity;
using GetHired.DataModels;
using GetHired.DataModels.Migrations;

namespace GetHired.ConsoleClient
{
    public class StartUp
    {
        public static void Main()
        {
            var context = new GetHiredContext();
            context.SaveChanges();
        }

        private static void Init()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<GetHiredContext, Configuration>());

            //AutomapperConfiguration.Initialize();
        }
    }
}
