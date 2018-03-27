using System.Data.Entity;
using AutoMapper;
using GetHired.ConsoleClient.HeroicMapperConfig;
using GetHired.DataModels;
using GetHired.DataModels.Migrations;
using GetHired.DomainModels;
using GetHired.DTO;

namespace GetHired.ConsoleClient
{
    public class StartUp
    {
        public static void Main()
        {
            Init();
            Mapper.Map<JobOffer, JobOfferModel>(new JobOffer());

            //json reader working
            //string fileName = "./../../Resources/import.json";

            //var reader = new JSONReader();
            //var result = reader.ReadFile(fileName);
            //Console.WriteLine(result);
        }

        private static void Init()
        {
            AutoMapperConfig.Configure();
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<GetHiredContext, Configuration>());
        }
    }
}