using backend.Database;
using backend.Models;

namespace backend.GraphQL.Mutations
{
    public class DocumentAccessMutations
    {
        public async Task<DocumentAccess> CreateDocumentAccessAsync(DocumentAccess input, [Service] AppDbContext dbContext)
        {
            dbContext.DocumentAccesses.Add(input);
            await dbContext.SaveChangesAsync();
            return input;
        }

        public async Task<DocumentAccess> UpdateDocumentAccessAsync(int documentAccessId, DocumentAccess input, [Service] AppDbContext dbContext)
        {
            var documentAccess = await dbContext.DocumentAccesses.FindAsync(documentAccessId);
            if (documentAccess == null) throw new Exception("Document Access not found");

            documentAccess.UserId = input.UserId;
            documentAccess.DocumentId = input.DocumentId;
            documentAccess.AccessLevel = input.AccessLevel;

            await dbContext.SaveChangesAsync();
            return documentAccess;
        }

        public async Task<bool> DeleteDocumentAccessAsync(int documentAccessId, [Service] AppDbContext dbContext)
        {
            var documentAccess = await dbContext.DocumentAccesses.FindAsync(documentAccessId);
            if (documentAccess == null) throw new Exception("Document Access not found");

            dbContext.DocumentAccesses.Remove(documentAccess);
            await dbContext.SaveChangesAsync();
            return true;
        }
    }

}
