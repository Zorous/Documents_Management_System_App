using HotChocolate;
using HotChocolate.Types;
using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Database;
using backend.Models;

namespace backend.GraphQL.Queries
{
    public class Queries
    {
        private readonly UserQuery _userQuery;
        private readonly DocumentQuery _documentQuery;
        private readonly RoleQuery _roleQuery;

        public Queries(UserQuery userQuery, DocumentQuery documentQuery, RoleQuery roleQuery)
        {
            _userQuery = userQuery;
            _documentQuery = documentQuery;
            _roleQuery = roleQuery;
        }

        // Delegate User-related queries
        public Task<IEnumerable<User>> GetUsers() => _userQuery.GetUsers(); // Returns non-nullable IEnumerable
        public Task<User?> GetUserById(int id) => _userQuery.GetUserById(id); // Returns nullable User

        // Delegate Document-related queries
        public Task<Document?> GetDocumentById(int id) => _documentQuery.GetDocumentById(id); // Returns nullable Document

        // Delegate Role-related queries
        public Task<Role?> GetRoleById(int id) => _roleQuery.GetRoleById(id); // Returns nullable Role
        public Task<IEnumerable<Role>> GetRoles() => _roleQuery.GetRoles(); // Returns non-nullable IEnumerable
    }
}
