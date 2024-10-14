using backend.Models;

namespace backend.GraphQL.Types
{
    public class PermissionType : ObjectType<Permission>
    {
        protected override void Configure(IObjectTypeDescriptor<Permission> descriptor)
        {
            descriptor.Field(p => p.PermissionId).Type<NonNullType<IntType>>();
            descriptor.Field(p => p.PermissionName).Type<NonNullType<StringType>>();
            descriptor.Field(p => p.CreatedAt).Type<NonNullType<DateTimeType>>();
            descriptor.Field(p => p.RolePermissions).Type<ListType<RolePermissionType>>();
        }
    }

}
