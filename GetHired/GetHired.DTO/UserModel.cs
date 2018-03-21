using System;
using GetHired.Common.Mapping;
using GetHired.DomainModels;

namespace GetHired.DTO
{
    public class UserModel : IMapFrom<User>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }
    }
}
