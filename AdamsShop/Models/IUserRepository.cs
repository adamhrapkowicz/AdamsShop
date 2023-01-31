using AdamsShop.DataModel;

namespace AdamsShop.Models
{
    public interface IUserRepository 
    {
        void CreateUser(MyUser myUser);

        List<MyUser> GetAllUsers();
    }
}
