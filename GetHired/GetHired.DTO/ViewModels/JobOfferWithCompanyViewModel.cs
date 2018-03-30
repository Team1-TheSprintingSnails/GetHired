﻿using AutoMapper;
using GetHired.DomainModels;
using GetHired.DomainModels.Enums;
using Heroic.AutoMapper;

namespace GetHired.DTO.ViewModels
{
    public class JobOfferWithCompanyViewModel : IMapFrom<JobOfferModel>, IMapTo<JobOfferModel>, IHaveCustomMappings
    {
        public int JobOfferId { get; set; }

        public string Position { get; set; }

        public string Description { get; set; }
        
        public decimal Payment { get; set; }

        public decimal JobOfferRating { get; set; }

        public JobType JobType { get; set; }

        public JobCategory JobCategory { get; set; }

        public int CompanyId { get; set; }

        public int CompanyName { get; set; }

        public int CompanyBusinessInfo { get; set; }

        public string CompanyWebsite { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<JobOffer, JobOfferWithCompanyViewModel>()
                .ForMember(d => d.JobOfferId, cfg => cfg.MapFrom(s => s.Id))
                .ForMember(d => d.JobOfferRating, cfg => cfg.MapFrom(s => s.Rating))
                .ForMember(d => d.CompanyName, cfg => cfg.MapFrom(s => s.Company.Name))
                .ForMember(d => d.CompanyBusinessInfo, cfg => cfg.MapFrom(s => s.Company.BusinessInfo))
                .ForMember(d => d.CompanyWebsite, cfg => cfg.MapFrom(s => s.Company.Website));

            configuration.CreateMap<JobOfferWithCompanyViewModel, JobOffer>()
                .ForMember(d => d.Id, cfg => cfg.MapFrom(s => s.JobOfferId))
                .ForMember(d => d.Rating, cfg => cfg.MapFrom(s => s.JobOfferRating));
        }
    }
}