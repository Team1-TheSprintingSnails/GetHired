using System;
using System.Data.Entity.Infrastructure;
using GetHired.DataModels;
using GetHired.DomainModels;
using GetHired.DomainModels.Enums;

namespace GetHired.ConsoleClient
{
    public class StartUp
    {
        public static void Main()
        {
            try
            {

                var context = new GetHiredContext();

                var user = new User { Role = Role.Regular, Username = "asdkljflkdsjfkjskld"};
                var pass

                context.Users.Add(user);

                context.SaveChanges();
            }

            catch (DbUpdateException e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
