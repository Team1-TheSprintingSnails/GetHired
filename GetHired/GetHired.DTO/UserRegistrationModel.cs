using System;
using GetHired.DomainModels;
using Heroic.AutoMapper;

namespace GetHired.DTO
{
    public class UserRegistrationModel : IMapTo<User>
    {
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }
        
        public DateTime? DataOfBirth { get; set; }
    }
}