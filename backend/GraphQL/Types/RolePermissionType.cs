using backend.Models;

namespace backend.GraphQL.Types
{
    public class RolePermissionType : ObjectType<RolePermission>
    {
        protected override void Configure(IObjectTypeDescriptor<RolePermission> descriptor)
        {
            descriptor.Field(rp => rp.RolePermissionId).Type<NonNullType<IntType>>();
            descriptor.Field(rp => rp.CreatedAt).Type<NonNullType<DateTimeType>>();
            descriptor.Field(rp => rp.RoleId).Type<NonNullType<IntType>>();
            descriptor.Field(rp => rp.Role).Type<RoleType>();
            descriptor.Field(rp => rp.PermissionId).Type<NonNullType<IntType>>();
            descriptor.Field(rp => rp.Permission).Type<PermissionType>();
        }
    }

}
