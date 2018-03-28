using System;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using AutoMapper;
using GetHired.ConsoleClient.HeroicAutoMapperConfig;
using GetHired.DataModels.Migrations;
using GetHired.DataModels.Models;
using GetHired.DomainModels;
using GetHired.DTO;

namespace GetHired.ConsoleClient
{
    public class StartUp
    {
        public static void Main()
        {
            Init();

            var um = new UserModel {UserId = 99};
            var user = Mapper.Map<User>(um);

            Console.WriteLine(user.Id);

            Console.WriteLine(GetSalt());
            Console.WriteLine(GetSalt());
            Console.WriteLine(GetSalt());

            var c = new GetHiredContext();

            var query = c.JobOffers
                .Include(x => x.Company)
                .Where(x => x.LikedBy.Any(u => u.Email.Equals("SomeEmail")));

            Console.WriteLine(query);
        }

        private static void Init()
        {
            AutoMapperConfig.Configure();
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<GetHiredContext, Configuration>());
        }

        public static string GetSalt()
        {
            var random = new RNGCryptoServiceProvider();

            // Maximum length of salt
            int maxLength = 32;

            // Empty salt array
            var salt = new byte[maxLength];

            // Build the random bytes
            random.GetNonZeroBytes(salt);

            // Return the string encoded salt
            return Convert.ToBase64String(salt);
        }
    }
}