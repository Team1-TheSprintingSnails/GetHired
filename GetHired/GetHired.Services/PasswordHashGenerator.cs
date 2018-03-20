using System;
using System.Security.Cryptography;
using System.Text;
using GetHired.Services.Contracts;

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

        public string GetSalt()
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