using GetHired.DataModels;
using GetHired.DomainModels;
using GetHired.DomainModels.Enums;

namespace GetHired.ConsoleClient
{
    public class StartUp
    {
        public static void Main()
        {
            var context = new GetHiredContext();

            var password = new Password();
            var user = new User { Role = Role.Regular, Username = "pesho999", Password = password };

            context.Users.Add(user);

            context.SaveChanges();
        }
    }
}
