namespace backend.Models
{
    public class User
    {
        public int UserId { get; set; }
        public int TenantId { get; set; }
        public string UserName { get; set; }
        public string ProfilePicture { get; set; } = "https://drive.google.com/uc?export=view&id=1JOUFiILM_vuNa0lPErQEpTeAZSibnwYE";
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation Properties
        public Tenant Tenant { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<Document> CreatedDocuments { get; set; }
        public ICollection<DocumentAccess> DocumentAccesses { get; set; }
    }

}