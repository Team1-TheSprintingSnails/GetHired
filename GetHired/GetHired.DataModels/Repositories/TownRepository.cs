using GetHired.DataModels.Contracts;
using GetHired.DataModels.Repositories.Contracts;
using GetHired.DomainModels;

namespace GetHired.DataModels.Repositories
{
    public class TownRepository : GenericRepository<Town>, ITownRepository
    {
        public TownRepository(IGetHiredContext context) : base(context)
        {
        }
    }
}
