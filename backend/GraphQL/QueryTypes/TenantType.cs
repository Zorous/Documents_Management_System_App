﻿using backend.Models;

namespace backend.GraphQL.QueryTypes
{
    public class TenantType
    {
        public int TenantId { get; set; }
        public string TenantName { get; set; }
        public string Domain { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation Properties
        public ICollection<User> Users { get; set; }
        public ICollection<Role> Roles { get; set; }
        public ICollection<Document> Documents { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}
