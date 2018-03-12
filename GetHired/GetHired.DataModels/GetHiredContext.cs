using System.Data.Entity;

namespace GetHired.DataModels
{
    public class GetHiredContext : DbContext
    {
        public GetHiredContext()
        : base("name=GetHired")
        { }
    }
}
