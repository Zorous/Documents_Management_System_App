using backend.Database;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.GraphQL.Queries
{
    public class DocumentAccessQuery
    {

        // Resolver to get a list of document accesses
        public async Task<IEnumerable<DocumentAccess>> GetDocumentAccesses([Service] AppDbContext dbContext)
        {
            return await dbContext.DocumentAccesses.ToListAsync();
        }

        // Resolver to get document access by ID
        public async Task<DocumentAccess> GetDocumentAccessById(int id, [Service] AppDbContext dbContext)
        {
            return await dbContext.DocumentAccesses.FindAsync(id);
        }
    }
}
