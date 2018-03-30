using GetHired.DataModels.Configurations.Contracts;
using GetHired.DataModels.Contracts;
using GetHired.DataModels.Models;
using GetHired.DomainModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetHired.DataModels.Configurations
{
    public class InitialDataConfiguration : DropCreateDatabaseIfModelChanges<GetHiredContext>
    {
        protected override void Seed(GetHiredContext context)
        {
            context.Towns.AddOrUpdate(x => x.Id,
             new City() { Id = 1, Name = "Lovech", State = "Lovech", Country = "Bulgaria" },
             new City() { Id = 2, Name = "Panagyurishte", State = "Pazardjik", Country = "Bulgaria" },
             new City() { Id = 3, Name = "Sofia", State = "Sofia", Country = "Bulgaria" },
             new City() { Id = 4, Name = "Plovdiv", State = "Plovdiv", Country = "Bulgaria" },
             new City() { Id = 5, Name = "Varna", State = "Varna", Country = "Bulgaria" },
             new City() { Id = 6, Name = "Burgas", State = "Burgas", Country = "Bulgaria" },
             new City() { Id = 7, Name = "Troyan", State = "Lovech", Country = "Bulgaria" },
             new City() { Id = 8, Name = "Sevlievo", State = "Gabrovo", Country = "Bulgaria" },
             new City() { Id = 9, Name = "Veliko Tarnovo", State = "Veliko Tarnovo", Country = "Bulgaria" },
             new City() { Id = 10, Name = "Silistra", State = "Silistra", Country = "Bulgaria" },
             new City() { Id = 11, Name = "Stara Zagora", State = "Stara Zagora", Country = "Bulgaria" },
             new City() { Id = 12, Name = "Ruse", State = "Ruse", Country = "Bulgaria" },
             new City() { Id = 13, Name = "Tryavna", State = "Gabrovo", Country = "Bulgaria" }
             );

            context.Companies.AddOrUpdate(x => x.Id,
                new Company() { Id = 1, BusinessInfo = "Cleaning company", PhoneNumber = "0887385956", DateModified = new System.DateTime(2012, 5, 17), DateCreated = new System.DateTime(2018, 3, 27), Name = "WashAndGo", Website = "https://www.washandgo.com" },
                new Company() { Id = 2, BusinessInfo = "Building company", PhoneNumber = "0887346231", DateModified = new System.DateTime(2011, 3, 15), DateCreated = new System.DateTime(2018, 2, 21), Name = "BuildCo", Website = "https://www.buildCompany.com" },
                new Company() { Id = 3, BusinessInfo = "Driving company", PhoneNumber = "0886545345", DateModified = new System.DateTime(2010, 2, 20), DateCreated = new System.DateTime(2018, 1, 4), Name = "Gracia", Website = "https://www.gracia-lovech.com" },
                new Company() { Id = 4, BusinessInfo = "Food company", PhoneNumber = "0874649664", DateModified = new System.DateTime(2009, 7, 24), DateCreated = new System.DateTime(2017, 12, 20), Name = "FreshBarKitchen", Website = "https://www.freshbar.com" },
                new Company() { Id = 5, BusinessInfo = "IT company", PhoneNumber = "0887766555", DateModified = new System.DateTime(2008, 8, 21), DateCreated = new System.DateTime(2018, 3, 4), Name = "Progress", Website = "https://www.progress.com" }
                );

            context.Addresses.AddOrUpdate(x => x.Id,
                new Address() { Id = 1, CompanyId = 5, DateModified = new System.DateTime(2010, 2, 20), DateCreated = new System.DateTime(2018, 1, 4), StreetName = "33 Alexander Malinov, 1729 Sofia", PostalCode = "1000", CityId = 3 },
                new Address() { Id = 2, CompanyId = 3, DateModified = new System.DateTime(2010, 2, 20), DateCreated = new System.DateTime(2018, 1, 4), StreetName = "21 Nikola Petkov, 5505 Lovech", PostalCode = "5500", CityId = 1 },
                new Address() { Id = 3, CompanyId = 2, DateModified = new System.DateTime(2010, 2, 20), DateCreated = new System.DateTime(2018, 1, 4), StreetName = "122 Cherni Vrah, 1526 Sofia", PostalCode = "1000", CityId = 10 },
                new Address() { Id = 4, CompanyId = 4, DateModified = new System.DateTime(2010, 2, 20), DateCreated = new System.DateTime(2018, 1, 4), StreetName = "Djuzepe Garivaldi Piazza", PostalCode = "1000", CityId = 3 },
                new Address() { Id = 5, CompanyId = 1, DateModified = new System.DateTime(2010, 2, 20), DateCreated = new System.DateTime(2018, 1, 4), StreetName = "23 Vasil Levski, 4000 Plovdiv", PostalCode = "4000", CityId = 4 }
                );

            base.Seed(context);
        }
    }
}