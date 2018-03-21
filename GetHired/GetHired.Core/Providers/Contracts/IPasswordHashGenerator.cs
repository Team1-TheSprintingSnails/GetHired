namespace GetHired.Core.Providers.Contracts
{
    public interface IPasswordHashGenerator
    {
        string GenerateSaltedHash(string plainText, string salt);
        string GetSalt();
    }
}