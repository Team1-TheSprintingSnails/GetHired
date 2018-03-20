namespace GetHired.Services
{
    public interface IPasswordHashGenerator
    {
        string GenerateSaltedHash(string plainText, string salt);
        string GetSalt();
    }
}