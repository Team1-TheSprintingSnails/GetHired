using System.Data.Entity;
using System.Reflection;
using Autofac;
using GetHired.Common;
using GetHired.DataModels;
using GetHired.DataModels.Migrations;
using GetHired.DomainModels;
using GetHired.DomainModels.Enums;

namespace GetHired.ConsoleClient
{
    public class StartUp
    {
        public static void Main()
        {
            Init();

            //var builder = new ContainerBuilder();
            //builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());
            //var container = builder.Build();
            
            var ctx = new GetHiredContext();
            ctx.Users.Add(new User()
            {
                Username = "laina",
                Role = Role.Regular
            });
        }

        private static void Init()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<GetHiredContext, Configuration>());

            AutomapperConfiguration.Initialize();
        }
    }
}
