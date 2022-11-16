namespace NZWalksAPI.Models.Domain
{
    public class Role
    {
        public Guid id { get; set; }
        public string Name { get; set; }

        // Navigation Property
        public List<User_Role> UserRoles { get; set; }
    }
}
