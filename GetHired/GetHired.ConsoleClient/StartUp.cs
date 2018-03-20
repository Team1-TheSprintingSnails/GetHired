using System.Data.Entity;
using System.Reflection;
using Autofac;
using GetHired.Common;
using GetHired.DataModels;
using GetHired.DataModels.Migrations;

namespace GetHired.ConsoleClient
{
    public class StartUp
    {
        public static void Main()
        {
            Init();

            var builder = new ContainerBuilder();
            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());
            var container = builder.Build();
            
        }

        private static void Init()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<GetHiredContext, Configuration>());

            AutomapperConfiguration.Initialize();
        }
    }
}
