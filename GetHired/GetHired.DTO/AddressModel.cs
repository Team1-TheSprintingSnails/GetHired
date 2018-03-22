using System;
using AutoMapper;
using GetHired.DomainModels;
using GetHired.DTO.Contracts;
using Heroic.AutoMapper;
using Microsoft.TeamFoundation.TestManagement.Client;

namespace GetHired.DTO
{
    public class AddressModel : IMapFrom<Address>, IMapTo<Address>, IIdentifiable<int>, IModificationHistory, IHaveCustomMappings
    {
        public AddressModel()
        { }

        public AddressModel(DateTime dateModified, DateTime dateCreated, int id)
        {
            this.DateModified = dateModified;
            this.DateCreated = dateCreated;
            this.Id = id;
        }

        public int Id { get; }

        public string Name { get; set; }

        public DateTime DateModified { get; }

        public DateTime DateCreated { get; }

        public virtual void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Address, AddressModel>()
                .ConstructUsing(x => new AddressModel(x.DateModified, x.DateCreated, x.Id));
        }
    }
}
