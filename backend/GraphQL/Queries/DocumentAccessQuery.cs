using backend.Database;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.GraphQL.Queries
{
    public class DocumentAccessQuery
    {
        private readonly AppDbContext _dbContext;

        // Inject AppDbContext via constructor
        public DocumentAccessQuery(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Resolver to get a list of document accesses
        public async Task<IEnumerable<DocumentAccess>> GetDocumentAccesses()
        {
            return await _dbContext.DocumentAccesses.ToListAsync();
        }

        // Resolver to get document access by ID
        public async Task<DocumentAccess?> GetDocumentAccessById(int id)
        {
            return await _dbContext.DocumentAccesses.FindAsync(id);
        }
    }
}
