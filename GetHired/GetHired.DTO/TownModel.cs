using System;
using AutoMapper;
using GetHired.DomainModels;
using GetHired.DTO.Contracts;
using Heroic.AutoMapper;
using Microsoft.TeamFoundation.TestManagement.Client;

namespace GetHired.DTO
{
    public class TownModel : IMapFrom<Town>, IMapTo<Town>, IIdentifiable<int>, IHaveCustomMappings, IModificationHistory
    {
        public TownModel()
        { }

        public TownModel(DateTime dateModified, DateTime dateCreated, int id)
        {
            this.DateModified = dateModified;
            this.DateCreated = dateCreated;
            this.Id = id;
        }

        public int Id { get; }

        public string Name { get; set; }

        public DateTime DateModified { get; }

        public DateTime DateCreated { get; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Town, TownModel>()
                .ConstructUsing(x => new TownModel(x.DateModified, x.DateCreated, x.Id));
        }
    }
}