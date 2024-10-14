namespace backend.Models
{
    public class Document
    {
        public int DocumentId { get; set; }
        public int TenantId { get; set; }
        public string DocumentName { get; set; }
        public string DocumentDescription { get; set; }
        public string Path { get; set; }
        public int? CreatedBy { get; set; }  // Nullable for ON DELETE SET NULL
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Navigation Properties
        public Tenant Tenant { get; set; }
        public User Creator { get; set; }
        public ICollection<DocumentAccess> DocumentAccesses { get; set; }
    }
}
