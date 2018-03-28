using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace GetHired.Services
{
    public class PasswordHashGenerator : IPasswordHashGenerator
    {
        public string GenerateSaltedHash(string password, string salt)
        {
            var plainTextWithSaltBytes = Encoding.ASCII.GetBytes(string.Concat(password, salt));

            HashAlgorithm algorithm = new SHA256Managed();
            var saltedHashBytes = algorithm.ComputeHash(plainTextWithSaltBytes);

            return Convert.ToBase64String(saltedHashBytes);
        }
    }
}