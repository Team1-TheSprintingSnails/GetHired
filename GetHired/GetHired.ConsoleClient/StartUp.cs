using GetHired.Core.Providers;
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
            

            context.SaveChanges();
        }
    }
}
