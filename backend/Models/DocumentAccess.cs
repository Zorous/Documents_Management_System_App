namespace backend.Models
{
    public class DocumentAccess
    {
        public int DocumentAccessId { get; set; }
        public int DocumentId { get; set; }
        public int UserId { get; set; }
        public string AccessLevel { get; set; }

        public bool IsActive { get; set; }
        public DateTime GrantedAt { get; set; }

        // Navigation Properties
        public Document Document { get; set; }
        public User User { get; set; }
    }

}