namespace backend.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation property to RolePermission
        public ICollection<RolePermission> RolePermissions { get; set; }

        // Navigation property to UserRole
        public ICollection<UserRole> UserRoles { get; set; }
    }

}
