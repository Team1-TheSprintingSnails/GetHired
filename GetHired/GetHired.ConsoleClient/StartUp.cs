using System;
using System.Data.Entity;
using AutoMapper;
using GetHired.ConsoleClient.HeroicMapperConfig;
using GetHired.DataModels;
using GetHired.DataModels.Migrations;
using GetHired.DataModels.UnitsOfWork;
using GetHired.DomainModels;
using GetHired.DTO;
using GetHired.Services.Services;

namespace GetHired.ConsoleClient
{
    public class StartUp
    {
        public static void Main()
        {
            Init();
            Mapper.Map<JobOffer, JobOfferModel>(new JobOffer());
        }
        
        private static void Init()
        {
            AutoMapperConfig.Configure();
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<GetHiredContext, Configuration>());
        }
    }
}