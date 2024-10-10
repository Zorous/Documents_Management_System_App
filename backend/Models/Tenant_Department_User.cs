namespace backend.Models
{
    public class Tenant_Department_User
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TenantId { get; set; }
        public int DepartmentId { get; set; }

        // Navigation Properties
        public User User { get; set; }
        public Tenant Tenant { get; set; }
        public Department Department { get; set; }
    }
}
