using System;
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
            ctx.Database.Log = Console.WriteLine;

            var find = ctx.Users.Find(1);
            var find1 = ctx.Users.Find(1);
            //Console.WriteLine(ctx.Entry(find).State);

            //var user = new User
            //{
            //    Username = find.Username,
            //    Id = find.Id,
            //    PasswordHash = find.PasswordHash,
            //    PasswordSalt = find.PasswordSalt,
            //    Role = find.Role
            //};
            //Console.WriteLine(ctx.Entry(user).State);

            ctx.SaveChanges();
            //var newUser = new User {Id = user.Id, Username = user.Username};
        }

        private static void Init()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<GetHiredContext, Configuration>());

            //AutomapperConfiguration.Initialize();
        }
    }
}
