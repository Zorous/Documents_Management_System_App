using HotChocolate.Types;
using backend.Models;
using HotChocolate.Resolvers;
using HotChocolate.Types.Relay;
using System.Xml.Linq;
using backend.GraphQL.Types;

public class Schemas : ObjectType
{
    protected override void Configure(IObjectTypeDescriptor descriptor)
    {
        descriptor.Name("Schemas");

        // User Type
        descriptor.Field("User")
            .ResolveWith<UserResolvers>(r => r.GetUser(default, default))
            .Type<UserType>();

        // Document Type
        descriptor.Field("Document")
            .ResolveWith<DocumentResolvers>(r => r.GetDocument(default, default))
            .Type<DocumentType>();

        // Role Type
        descriptor.Field("Role")
            .ResolveWith<RoleResolvers>(r => r.GetRole(default, default))
            .Type<RoleType>();

        // Tenant Type
        descriptor.Field("Tenant")
            .ResolveWith<TenantResolvers>(r => r.GetTenant(default, default))
            .Type<TenantType>();

        // Document Access Type
        descriptor.Field("DocumentAccess")
            .ResolveWith<DocumentAccessResolvers>(r => r.GetDocumentAccess(default, default))
            .Type<DocumentAccessType>();

        // User Role Type
        descriptor.Field("UserRole")
            .ResolveWith<UserRoleResolvers>(r => r.GetUserRole(default, default))
            .Type<UserRoleType>();

        // Role Permission Type
        descriptor.Field("RolePermission")
            .ResolveWith<RolePermissionResolvers>(r => r.GetRolePermission(default, default))
            .Type<RolePermissionType>();

        // Payment Type
        descriptor.Field("Payment")
            .ResolveWith<PaymentResolvers>(r => r.GetPayment(default, default))
            .Type<PaymentType>();

        // Department Type
        descriptor.Field("Department")
            .ResolveWith<DepartmentResolvers>(r => r.GetDepartment(default, default))
            .Type<DepartmentType>();

        // Tenant_Department_User Type
        descriptor.Field("Tenant_Department_User")
            .ResolveWith<Tenant_Department_UserResolvers>(r => r.GetTenant_Department_User(default, default))
            .Type<Tenant_Department_UserType>();

        // Permission Type
        descriptor.Field("Permission")
            .ResolveWith<PermissionResolvers>(r => r.GetPermission(default, default))
            .Type<PermissionType>();
    }
}

// Resolvers
public class UserResolvers
{
    public User GetUser(IResolverContext context, int userId)
    {
        // Fetch and return the User data by userId
        return new User(); // Replace with actual data fetching logic
    }
}

public class DocumentResolvers
{
    public Document GetDocument(IResolverContext context, int documentId)
    {
        // Fetch and return the Document data by documentId
        return new Document(); // Replace with actual data fetching logic
    }
}

public class RoleResolvers
{
    public Role GetRole(IResolverContext context, int roleId)
    {
        // Fetch and return the Role data by roleId
        return new Role(); // Replace with actual data fetching logic
    }
}

public class TenantResolvers
{
    public Tenant GetTenant(IResolverContext context, int tenantId)
    {
        // Fetch and return the Tenant data by tenantId
        return new Tenant(); // Replace with actual data fetching logic
    }
}

public class DocumentAccessResolvers
{
    public DocumentAccess GetDocumentAccess(IResolverContext context, int documentAccessId)
    {
        // Fetch and return the DocumentAccess data by documentAccessId
        return new DocumentAccess(); // Replace with actual data fetching logic
    }
}

public class UserRoleResolvers
{
    public UserRole GetUserRole(IResolverContext context, int userRoleId)
    {
        // Fetch and return the UserRole data by userRoleId
        return new UserRole(); // Replace with actual data fetching logic
    }
}

public class RolePermissionResolvers
{
    public RolePermission GetRolePermission(IResolverContext context, int rolePermissionId)
    {
        // Fetch and return the RolePermission data by rolePermissionId
        return new RolePermission(); // Replace with actual data fetching logic
    }
}

public class PaymentResolvers
{
    public Payment GetPayment(IResolverContext context, int paymentId)
    {
        // Fetch and return the Payment data by paymentId
        return new Payment(); // Replace with actual data fetching logic
    }
}

public class DepartmentResolvers
{
    public Department GetDepartment(IResolverContext context, int departmentId)
    {
        // Fetch and return the Department data by departmentId
        return new Department(); // Replace with actual data fetching logic
    }
}

public class Tenant_Department_UserResolvers
{
    public Tenant_Department_User GetTenant_Department_User(IResolverContext context, int id)
    {
        // Fetch and return the Tenant_Department_User data by id
        return new Tenant_Department_User(); // Replace with actual data fetching logic
    }
}

public class PermissionResolvers
{
    public Permission GetPermission(IResolverContext context, int permissionId)
    {
        // Fetch and return the Permission data by permissionId
        return new Permission(); // Replace with actual data fetching logic
    }
}
