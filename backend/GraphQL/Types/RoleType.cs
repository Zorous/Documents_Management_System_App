using backend.Models;

namespace backend.GraphQL.Types
{
    public class RoleType : ObjectType<Role>
    {
        protected override void Configure(IObjectTypeDescriptor<Role> descriptor)
        {
            descriptor.Field(r => r.RoleId).Type<NonNullType<IntType>>();
            descriptor.Field(r => r.RoleName).Type<NonNullType<StringType>>();
            descriptor.Field(r => r.CreatedAt).Type<NonNullType<DateTimeType>>();
            descriptor.Field(r => r.RolePermissions).Type<ListType<RolePermissionType>>();
            descriptor.Field(r => r.UserRoles).Type<ListType<UserRoleType>>();
        }
    }

}
