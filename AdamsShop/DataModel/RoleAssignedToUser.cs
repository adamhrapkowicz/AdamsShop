namespace AdamsShop.DataModel
{
    public class RoleAssignedToUser
    {
        public int Id { get; set; }

        public MyRole MyRole { get; set; } = default!;

        public MyUser MyUser { get; set; } = default!;
    
    }
}
