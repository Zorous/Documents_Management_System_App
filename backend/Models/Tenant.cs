using System.Data;
using System.Reflection.Metadata;

namespace backend.Models
{
    public class Tenant
    {
        public int TenantId { get; set; }
        public string TenantName { get; set; }
        public string Domain { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation Properties
        public ICollection<Document> Documents { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<Tenant_Department_User> Tenant_Department_Users { get; set; }
        public ICollection<UserRole> Roles { get; set; }
    }
}
