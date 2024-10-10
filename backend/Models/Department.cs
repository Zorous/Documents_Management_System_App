
namespace backend.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation Property
        public ICollection<Tenant_Department_User> Tenant_Department_Users { get; set; }
    }
}
