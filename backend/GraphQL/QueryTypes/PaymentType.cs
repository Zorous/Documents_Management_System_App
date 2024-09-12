using backend.Models;

namespace backend.GraphQL.QueryTypes
{
    public class PaymentType
    {
        public int PaymentId { get; set; }
        public int TenantId { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; }
        public decimal Amount { get; set; }
        public DateTime? PaidAt { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation Properties
        public Tenant Tenant { get; set; }
    }
}
