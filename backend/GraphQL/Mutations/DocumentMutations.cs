
using backend.Database;
using backend.Models;

namespace backend.GraphQL.Mutations
{
    public class DocumentMutations



    {
        public async Task<Document> CreateDocumentAsync(Document input, [Service] AppDbContext dbContext)
        {
            dbContext.Documents.Add(input);
            await dbContext.SaveChangesAsync();
            return input;
        }

        public async Task<Document> UpdateDocumentAsync(int documentId, Document input, [Service] AppDbContext dbContext)
        {
            var document = await dbContext.Documents.FindAsync(documentId);
            if (document == null) throw new Exception("Document not found");

            document.DocumentName = input.DocumentName;
            document.DocumentDescription = input.DocumentDescription;
            document.Path = input.Path;
            document.CreatedBy = input.CreatedBy;
            document.UpdatedAt = DateTime.UtcNow; // Updating timestamp

            await dbContext.SaveChangesAsync();
            return document;
        }

        public async Task<bool> DeleteDocumentAsync(int documentId, [Service] AppDbContext dbContext)
        {
            var document = await dbContext.Documents.FindAsync(documentId);
            if (document == null) throw new Exception("Document not found");

            dbContext.Documents.Remove(document);
            await dbContext.SaveChangesAsync();
            return true;
        }
    }
}
