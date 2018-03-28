using System.Collections.Generic;

namespace GetHired.Services
{
    public interface IPasswordHashGenerator
    {
        string GenerateSaltedHash(string plainText, string salt);
    }
}