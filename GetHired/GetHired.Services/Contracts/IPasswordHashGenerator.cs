namespace GetHired.Services.Contracts
{
    public interface IPasswordHashGenerator
    {
        string GenerateSaltedHash(string plainText, string salt);
        string GetSalt();
    }
}