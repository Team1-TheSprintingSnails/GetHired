using GetHired.DataModels.Contracts;
using GetHired.Services.Contracts;

namespace GetHired.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {

        }
    }
}
