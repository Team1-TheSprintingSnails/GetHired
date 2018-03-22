using System.Data.Entity;
using AutoMapper;
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

            var service = new JobOfferService(new UnitOfWork(new GetHiredContext()), Mapper.Instance);

            var c = new CompanyModel{};
            var jt = new JobTypeModel();
            var jc = new JobCategoryModel();

            var jo = new JobOffer();

        }
        
        private static void Init()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<GetHiredContext, Configuration>());
        }
    }
}