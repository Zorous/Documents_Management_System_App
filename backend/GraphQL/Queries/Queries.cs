using HotChocolate;
using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Models;

namespace backend.GraphQL.Queries
{
    public class Queries
    {
        private readonly UserQuery _userQuery;
        private readonly DocumentQuery _documentQuery;
        private readonly RoleQuery _roleQuery;

        public Queries(
            [Service] UserQuery userQuery,
            [Service] DocumentQuery documentQuery,
            [Service] RoleQuery roleQuery)
        {
            _userQuery = userQuery;
            _documentQuery = documentQuery;
            _roleQuery = roleQuery;
        }

        // Delegate User-related queries
        public Task<IEnumerable<User>> GetUsers() => _userQuery.GetUsers();
        public Task<User?> GetUserById(int id) => _userQuery.GetUserById(id);

        // Delegate Document-related queries
        public Task<Document?> GetDocumentById(int id) => _documentQuery.GetDocumentById(id);

        // Delegate Role-related queries
        public Task<Role?> GetRoleById(int id) => _roleQuery.GetRoleById(id);
        public Task<IEnumerable<Role>> GetRoles() => _roleQuery.GetRoles();
    }
}
