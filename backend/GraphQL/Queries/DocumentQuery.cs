using backend.Database;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.GraphQL.Queries
{
    public class DocumentQuery
    {
        private readonly AppDbContext _context;
        // Inject AppDbContext into the query class
        public DocumentQuery(AppDbContext context)
        {
            _context = context;
        }
        // Resolver to get a list of documents
        public async Task<IEnumerable<Document>> GetDocuments()
        {
            return await _context.Documents.ToListAsync();
        }

        // Resolver to get a document by ID
        public async Task<Document?> GetDocumentById(int id)
        {
            return await _context.Documents.FindAsync(id);
        }

    }
}
