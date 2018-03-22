using System;
using AutoMapper;
using GetHired.DomainModels;
using GetHired.DTO.Contracts;
using Heroic.AutoMapper;
using Microsoft.TeamFoundation.TestManagement.Client;

namespace GetHired.DTO
{
    public class JobOfferModel : IMapFrom<JobOffer>, IMapTo<JobOffer>, IIdentifiable<int>, IHaveCustomMappings, IModificationHistory
    {
        public JobOfferModel()
        { }

        public JobOfferModel(DateTime dateModified, DateTime dateCreated, int id)
        {
            this.DateModified = dateModified;
            this.DateCreated = dateCreated;
            this.Id = id;
        }

        public int Id { get; }

        public string Position { get; set; }

        public string Description { get; set; }

        public decimal Payment { get; set; }

        public DateTime DateModified { get; }

        public DateTime DateCreated { get; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<JobOffer, JobOfferModel>()
                .ConstructUsing(x => new JobOfferModel(x.DateModified, x.DateCreated, x.Id));
        }
    }
}