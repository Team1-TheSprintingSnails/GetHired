using System;
using AutoMapper;
using GetHired.DomainModels;
using GetHired.DTO.Contracts;
using Heroic.AutoMapper;
using Microsoft.TeamFoundation.TestManagement.Client;

namespace GetHired.DTO
{
    public class CompanyModel : IMapFrom<Company>, IMapTo<Company>, IIdentifiable<int>, IHaveCustomMappings, IModificationHistory
    {
        public CompanyModel()
        { }

        public CompanyModel(DateTime dateModified, DateTime dateCreated, int id)
        {
            this.DateModified = dateModified;
            this.DateCreated = dateCreated;
            this.Id = id;
        }

        public int Id { get; }

        public string BusinessInfo { get; set; }

        public DateTime DateModified { get; }

        public DateTime DateCreated { get; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Company, CompanyModel>()
                .ConstructUsing(x => new CompanyModel(x.DateModified, x.DateCreated, x.Id));
        }
    }
}