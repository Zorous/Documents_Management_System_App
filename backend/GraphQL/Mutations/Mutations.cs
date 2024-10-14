using backend.GraphQL.Mutations;
using HotChocolate;

namespace backend.GraphQL
{
    public class Mutation
    {
        public UserMutations UserMutations { get; set; }
        public DepartmentMutations DepartmentMutations { get; set; }
        public DocumentMutations DocumentMutations { get; set; }
        public RoleMutations RoleMutations { get; set; }
        public TenantMutations TenantMutations { get; set; }
        public DocumentAccessMutations DocumentAccessMutations { get; set; }
        public UserRoleMutations UserRoleMutations { get; set; }
        public RolePermissionMutations RolePermissionMutations { get; set; }
        public PaymentMutations PaymentMutations { get; set; }
        public Tenant_Department_UserMutations Tenant_Department_UserMutations { get; set; }
        public PermissionMutations PermissionMutations { get; set; }

        public Mutation(
            UserMutations userMutations,
            DepartmentMutations departmentMutations,
            DocumentMutations documentMutations,
            RoleMutations roleMutations,
            TenantMutations tenantMutations,
            DocumentAccessMutations documentAccessMutations,
            UserRoleMutations userRoleMutations,
            RolePermissionMutations rolePermissionMutations,
            PaymentMutations paymentMutations,
            Tenant_Department_UserMutations tenant_Department_UserMutations,
            PermissionMutations permissionMutations)
        {
            UserMutations = userMutations;
            DepartmentMutations = departmentMutations;
            DocumentMutations = documentMutations;
            RoleMutations = roleMutations;
            TenantMutations = tenantMutations;
            DocumentAccessMutations = documentAccessMutations;
            UserRoleMutations = userRoleMutations;
            RolePermissionMutations = rolePermissionMutations;
            PaymentMutations = paymentMutations;
            Tenant_Department_UserMutations = tenant_Department_UserMutations;
            PermissionMutations = permissionMutations;
        }
    }
}
