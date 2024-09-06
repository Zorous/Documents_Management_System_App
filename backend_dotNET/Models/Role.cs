namespace backend_dotNET.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public int TenantId { get; set; }
        public string RoleName { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation Properties
        public Tenant Tenant { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<RolePermission> RolePermissions { get; set; }
    }

}