namespace backend.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string ProfilePicture { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<Document> CreatedDocuments { get; set; }
        public ICollection<DocumentAccess> DocumentAccesses { get; set; }
        // Navigation Properties
        public ICollection<Tenant_Department_User> Tenant_Department_Users { get; set; }
    }

}