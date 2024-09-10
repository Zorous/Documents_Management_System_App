namespace backend.Models
{
    public class Permission
    {
        public int PermissionId { get; set; }
        public string PermissionName { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation Properties
        public ICollection<RolePermission> RolePermissions { get; set; }
    }

}