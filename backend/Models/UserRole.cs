﻿namespace backend.Models
{
    public class UserRole
    {
        public int UserRoleId { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public int TenantId { get; set; } // New property
        public DateTime CreatedAt { get; set; }

        // Navigation Properties
        public User User { get; set; }
        public Role Role { get; set; }
        public Tenant Tenant { get; set; } // New navigation property
    }
}
