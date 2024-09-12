using System;
using System.Linq;
using backend.Database;
using backend.Models;

public static class DbInitializer
{
    public static void Seed(AppDbContext context)
    {
        // Check if the database is already seeded
        if (context.Tenants.Any())
        {
            return; // DB has been seeded
        }

        // Seed Tenants
        context.Tenants.AddRange(
            new Tenant { TenantId = 1, TenantName = "Acme Corp", Domain = "acme.com", CreatedAt = DateTime.UtcNow },
            new Tenant { TenantId = 2, TenantName = "Global Solutions", Domain = "globalsolutions.com", CreatedAt = DateTime.UtcNow },
            new Tenant { TenantId = 3, TenantName = "Tech Innovators", Domain = "techinnovators.com", CreatedAt = DateTime.UtcNow }
        );
        context.SaveChanges();

        // Seed Users
        context.Users.AddRange(
            new User { UserId = 1, TenantId = 1, UserName = "JohnDoe", Email = "john.doe@acme.com", PasswordHash = "hashed_password_1", CreatedAt = DateTime.UtcNow },
            new User { UserId = 2, TenantId = 1, UserName = "JaneDoe", Email = "jane.doe@acme.com", PasswordHash = "hashed_password_2", CreatedAt = DateTime.UtcNow }
        );
        context.SaveChanges();

        // Seed Documents
        context.Documents.AddRange(
            new Document { DocumentId = 1, TenantId = 1, DocumentName = "Doc1", Content = "Content for doc 1", CreatedBy = 1, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new Document { DocumentId = 2, TenantId = 1, DocumentName = "Doc2", Content = "Content for doc 2", CreatedBy = 2, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
        );
        context.SaveChanges();

        // Seed other tables similarly...
    }
}
