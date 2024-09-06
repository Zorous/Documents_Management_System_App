namespace backend_dotNET.Models
{
    public class RolePermission
    {
        public int RolePermissionId { get; set; }
        public int RoleId { get; set; }
        public int PermissionId { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation Properties
        public Role Role { get; set; }
        public Permission Permission { get; set; }
    }

}