namespace backend.Models
{
    public class RolePermission
    {
        public int RolePermissionId { get; set; }
        public DateTime CreatedAt { get; set; }


        // Foreign Key to Role
        public int RoleId { get; set; }
        public Role Role { get; set; }

        // Foreign Key to Permission
        public int PermissionId { get; set; }
        public Permission Permission { get; set; }
    }

}