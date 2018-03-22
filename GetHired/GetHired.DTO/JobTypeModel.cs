using System;
using AutoMapper;
using GetHired.DomainModels;
using GetHired.DTO.Contracts;
using Heroic.AutoMapper;
using Microsoft.TeamFoundation.TestManagement.Client;

namespace GetHired.DTO
{
    public class JobTypeModel : IMapFrom<JobType>, IMapTo<JobType>, IIdentifiable<int>, IHaveCustomMappings, IModificationHistory
    {
        public JobTypeModel()
        { }

        public JobTypeModel(DateTime dateModified, DateTime dateCreated, int id)
        {
            this.DateModified = dateModified;
            this.DateCreated = dateCreated;
            this.Id = id;
        }

        public int Id { get; }

        public string TypeName { get; set; }

        public DateTime DateModified { get; }

        public DateTime DateCreated { get; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<JobType, JobTypeModel>()
                .ConstructUsing(x => new JobTypeModel(x.DateModified, x.DateCreated, x.Id));
        }
    }
}