using HotChocolate;
using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Models;

namespace backend.GraphQL.Queries
{
    public class Queries
    {
        private readonly UserQuery _userQuery;
        private readonly UserRoleQuery _userRoleQuery;

        private readonly DocumentQuery _documentQuery;
        private readonly RoleQuery _roleQuery;
        private readonly TenantQuery _tenantQuery;
        private readonly DepartmentQuery _departmentQuery;
        private readonly DocumentAccessQuery _documentAccessQuery;
        private readonly Tenant_Department_User_Query _tenantDepartmentUserQuery;
        private readonly PermissionQuery _permissionQuery;
        private readonly PaymentQuery _paymentQuery;
        private readonly RolePermissionQuery _rolePermissionQuery;



        public Queries(
            [Service] UserQuery userQuery,
            [Service] UserRoleQuery userRoleQuery,
            [Service] DocumentQuery documentQuery,
            [Service] RoleQuery roleQuery,
            [Service] TenantQuery tenantQuery,
            [Service] DepartmentQuery departmentQuery,
            [Service] DocumentAccessQuery documentAccessQuery,
            [Service] Tenant_Department_User_Query tenantDepartmentUserQuery,
            [Service] PermissionQuery permissionQuery,
            [Service] PaymentQuery paymentQuery,
            [Service] RolePermissionQuery rolePermissionQuery

            )


        {
            _userQuery = userQuery;
            _userRoleQuery = userRoleQuery;
            _documentQuery = documentQuery;
            _roleQuery = roleQuery;
            _tenantQuery = tenantQuery;
            _departmentQuery = departmentQuery;
            _documentAccessQuery = documentAccessQuery;
            _tenantDepartmentUserQuery = tenantDepartmentUserQuery;
            _permissionQuery = permissionQuery;
            _paymentQuery = paymentQuery;
            _rolePermissionQuery = rolePermissionQuery;


        }

        // User-related queries
        public Task<IEnumerable<User>> GetUsers() => _userQuery.GetUsers();
        public Task<User?> GetUserById(int id) => _userQuery.GetUserById(id);

        // Document-related queries
        public Task<Document?> GetDocumentById(int id) => _documentQuery.GetDocumentById(id);
        public Task<IEnumerable<Document>> GetDocuments() => _documentQuery.GetDocuments();

        // Role-related queries
        public Task<Role?> GetRoleById(int id) => _roleQuery.GetRoleById(id);
        public Task<IEnumerable<Role>> GetRoles() => _roleQuery.GetRoles();

        // Tenant-related queries
        public Task<IEnumerable<Tenant>> GetTenants() => _tenantQuery.GetTenants();
        public Task<Tenant?> GetTenantById(int id) => _tenantQuery.GetTenantById(id);

        // Department-related queries
        public Task<Department?> GetDepartmentById(int id) => _departmentQuery.GetDepartmentById(id);
        public Task<IEnumerable<Department>> GetDepartments() => _departmentQuery.GetDepartments();

        // DocumentAccess-related queries
        public Task<DocumentAccess?> GetDocumentAccessById(int id) => _documentAccessQuery.GetDocumentAccessById(id);
        public Task<IEnumerable<DocumentAccess>> GetDocumentAccesses() => _documentAccessQuery.GetDocumentAccesses();

        // Tenant_Department_User-related queries
        public Task<IEnumerable<Tenant_Department_User>> GetAllTenantDepartmentUsers() => _tenantDepartmentUserQuery.GetAllTenantDepartmentUsers();
        public Task<Tenant_Department_User?> GetTenantDepartmentUserByIds(int tenantId, int departmentId, int userId) => _tenantDepartmentUserQuery.GetTenantDepartmentUserByIds(tenantId, departmentId, userId);


        // UserRole-related queries
        public Task<IEnumerable<UserRole>> GetAllUserRoles() => _userRoleQuery.GetAllUserRoles();
        public Task<UserRole?> GetUserRoleById(int id) => _userRoleQuery.GetUserRoleById(id);

        // Permissions queries
        public Task<IEnumerable<Permission>> GetPermissions() => _permissionQuery.GetPermissions();
        public Task<Permission?> GetPermissionById(int id) => _permissionQuery.GetPermissionById(id);

        // Payment-related queries
        public Task<IEnumerable<Payment>> GetPayments() => _paymentQuery.GetPayments();
        public Task<Payment?> GetPaymentById(int id) => _paymentQuery.GetPaymentById(id);



        // RolePermission-related queries
        public Task<IEnumerable<RolePermission>> GetRolePermissions() => _rolePermissionQuery.GetRolePermissions();
        public Task<RolePermission?> GetRolePermissionById(int id) => _rolePermissionQuery.GetRolePermissionById(id);



    }
}
