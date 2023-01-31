namespace AdamsShop.Models
{
    public class MyPasswordHasher : IMyPasswordHasher
    {
        public string GenerateMyPasswordHash(string password)
        {
            //var salt = RandomNumberGenerator;
            var hash = password.GetHashCode();
            return hash.ToString();
        }

        public bool VerifyMyPassword(string savedPassword, string inputPassword)
        {
            return savedPassword == GenerateMyPasswordHash(inputPassword);
        }
    }
}
