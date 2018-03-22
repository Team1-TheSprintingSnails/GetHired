using System;
using GetHired.DomainModels;
using Heroic.AutoMapper;

namespace GetHired.DTO
{
    public class UserModel : IMapFrom<User>, IMapTo<User>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }
    }
}
