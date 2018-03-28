using System;
using AutoMapper;
using GetHired.DomainModels;
using Heroic.AutoMapper;

namespace GetHired.DTO
{
    public class UserModel : IMapFrom<User>, IMapTo<User>, IHaveCustomMappings
    {
        public int UserId { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public DateTime? DataOfBirth { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<User, UserModel>()
                .ForMember(d => d.UserId, cfg => cfg.MapFrom(s => s.Id));

            configuration.CreateMap<UserModel, User>()
                .ForMember(d => d.Id, cfg => cfg.MapFrom(s => s.UserId));
        }
    }
}
