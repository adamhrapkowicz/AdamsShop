using AdamsShop.DataModel;

namespace AdamsShop.Models
{
    public interface IMyRoleRepository
    {
        public void CreateMyRole(MyRole myRole);

        void RemoveMyRole(MyRole myRole);

        List<MyRole> GetAllRoles();
    }
}
