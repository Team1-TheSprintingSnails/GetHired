using GetHired.DataModels;

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
