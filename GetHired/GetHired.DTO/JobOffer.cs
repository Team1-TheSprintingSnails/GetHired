using AutoMapper;
using GetHired.DomainModels;
using GetHired.DomainModels.Enums;
using Heroic.AutoMapper;

namespace GetHired.DTO
{
    public class JobOfferModel : IMapFrom<JobOfferModel>, IMapTo<JobOfferModel>, IHaveCustomMappings
    {
        public int JobOfferId { get; set; }

        public string Position { get; set; }

        public string Description { get; set; }

        public decimal Payment { get; set; }

        public decimal JobOfferRating { get; set; }

        public JobType JobType { get; set; }

        public JobCategory JobCategory { get; set; }

        public int CompanyId { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<JobOffer, JobOfferModel>()
                .ForMember(d => d.JobOfferId, cfg => cfg.MapFrom(s => s.Id))
                .ForMember(d => d.JobOfferRating, cfg => cfg.MapFrom(s => s.Rating));

            configuration.CreateMap<JobOfferModel, JobOffer>()
                .ForMember(d => d.Id, cfg => cfg.MapFrom(s => s.JobOfferId))
                .ForMember(d => d.Rating, cfg => cfg.MapFrom(s => s.JobOfferRating));
        }
    }
}