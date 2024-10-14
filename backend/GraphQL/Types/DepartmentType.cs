using backend.Models;

namespace backend.GraphQL.Types
{
    public class DepartmentType : ObjectType<Department>
    {
        protected override void Configure(IObjectTypeDescriptor<Department> descriptor)
        {
            descriptor.Field(d => d.DepartmentId).Type<NonNullType<IntType>>();
            descriptor.Field(d => d.DepartmentName).Type<NonNullType<StringType>>();
            descriptor.Field(d => d.CreatedAt).Type<NonNullType<DateTimeType>>();
            descriptor.Field(d => d.Tenant_Department_Users).Type<ListType<Tenant_Department_UserType>>();
        }
    }

}
