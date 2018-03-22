using System;
using AutoMapper;
using GetHired.DomainModels;
using GetHired.DTO.Contracts;
using Heroic.AutoMapper;
using Microsoft.TeamFoundation.TestManagement.Client;

namespace GetHired.DTO
{
    public class JobCategoryModel : IMapFrom<JobCategory>, IMapTo<JobCategory>, IIdentifiable<int>, IHaveCustomMappings, IModificationHistory
    {
        public JobCategoryModel()
        { }

        public JobCategoryModel(DateTime dateModified, DateTime dateCreated, int id)
        {
            this.DateModified = dateModified;
            this.DateCreated = dateCreated;
            this.Id = id;
        }
        
        public int Id { get; }

        public string CategoryName { get; set; }

        public DateTime DateModified { get; }

        public DateTime DateCreated { get; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<JobCategory, JobCategoryModel>()
                .ConstructUsing(x => new JobCategoryModel(x.DateModified, x.DateCreated, x.Id));
        }
    }
}
