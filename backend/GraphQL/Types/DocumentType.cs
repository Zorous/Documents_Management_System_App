using backend.Models;

namespace backend.GraphQL.Types
{
    public class DocumentType : ObjectType<Document>
    {
        protected override void Configure(IObjectTypeDescriptor<Document> descriptor)
        {
            descriptor.Field(d => d.DocumentId).Type<NonNullType<IntType>>();
            descriptor.Field(d => d.TenantId).Type<NonNullType<IntType>>();
            descriptor.Field(d => d.DocumentName).Type<NonNullType<StringType>>();
            descriptor.Field(d => d.DocumentDescription).Type<StringType>();
            descriptor.Field(d => d.Path).Type<NonNullType<StringType>>();
            descriptor.Field(d => d.CreatedBy).Type<IntType>();
            descriptor.Field(d => d.CreatedAt).Type<NonNullType<DateTimeType>>();
            descriptor.Field(d => d.UpdatedAt).Type<NonNullType<DateTimeType>>();
            descriptor.Field(d => d.Tenant).Type<TenantType>();
            descriptor.Field(d => d.Creator).Type<UserType>();
            descriptor.Field(d => d.DocumentAccesses).Type<ListType<DocumentAccessType>>();
        }
    }


}
