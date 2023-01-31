using AdamsShop.DataModel;
using Microsoft.AspNetCore.Identity;
using AdamsShop.Models;

namespace AdamsShop.Models
{
    public class UserRepository : IUserRepository
    {
        private readonly AdamsShopDbContext _adamsShopDbContext;
        private readonly IMyPasswordHasher _myPasswordHasher;

        public UserRepository(AdamsShopDbContext adamsShopDbContext, IMyPasswordHasher myPasswordHasher)
        {
            _adamsShopDbContext = adamsShopDbContext;
            _myPasswordHasher=myPasswordHasher;
        }

        public void CreateUser(MyUser myUser)
        {
            myUser.Password = _myPasswordHasher.GenerateMyPasswordHash(myUser.Password);

            myUser.ConfirmPassword = _myPasswordHasher.GenerateMyPasswordHash(myUser.ConfirmPassword);

            _adamsShopDbContext.MyUsers.Add(myUser);
            _adamsShopDbContext.SaveChanges();
        }

        public List<MyUser> GetAllUsers()
        {
            return _adamsShopDbContext.MyUsers.ToList();
        }
    }
}
