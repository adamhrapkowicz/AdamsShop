namespace AdamsShop.Models
{
    public interface IMyPasswordHasher
    {
        string GenerateMyPasswordHash(string password);
        bool VerifyMyPassword(string savedPassword, string inputPassword);
    }
}
