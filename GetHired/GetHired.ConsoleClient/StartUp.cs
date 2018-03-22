using System;
using System.Data.Entity;
using AutoMapper;
using GetHired.ConsoleClient.HeroicMapperConfig;
using GetHired.Core.Providers;
using GetHired.DataModels;
using GetHired.DataModels.Migrations;
using GetHired.DataModels.Repositories;
using GetHired.DomainModels;
using GetHired.DTO;

namespace GetHired.ConsoleClient
{
    public class StartUp
    {
        public static void Main()
        {
            Init();

            AutoMapperConfig.Configure();

            var ctx = new GetHiredContext();
            ctx.Database.Log = Console.WriteLine;

            //map from address -> addressmodel

            //var a = new Address()
            //{`
            //    Id = 99,
            //    Name = "some name here",
            //    DateModified = DateTime.Now,
            //    DateCreated = DateTime.Now
            //};


            //var model = Mapper.Map<Address, AddressModel>(a);

            //Console.WriteLine(model.DateCreated);
            //Console.WriteLine(model.DateModified);
            //Console.WriteLine(model.Id);
            //Console.WriteLine(model.Name);

            //var model = new AddressModel(DateTime.Now, DateTime.Now, 89);
            //model.Name = "adasdasa";
            //var a = Mapper.Map<AddressModel, Address>(model);
            //Console.WriteLine(a.DateModified);
            //Console.WriteLine(a.DateCreated);
            //Console.WriteLine(a.Id);
            //Console.WriteLine(a.Name);  

            var town = new Town()
            {
                Id = 1,
                Name = "nqkyv town some another",
                DateCreated = DateTime.Now
            };
            var townRepo = new TownRepository(ctx);
            //townRepo.Insert(town);
            townRepo.Update(town);
            ctx.SaveChanges();
        }
        
        private static void Init()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<GetHiredContext, Configuration>());
        }
    }
}