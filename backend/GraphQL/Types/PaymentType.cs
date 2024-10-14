using backend.Models;

namespace backend.GraphQL.Types
{
    public class PaymentType : ObjectType<Payment>
    {
        protected override void Configure(IObjectTypeDescriptor<Payment> descriptor)
        {
            descriptor.Field(p => p.PaymentId).Type<NonNullType<IntType>>();
            descriptor.Field(p => p.TenantId).Type<NonNullType<IntType>>();
            descriptor.Field(p => p.PaymentMethod).Type<NonNullType<StringType>>();
            descriptor.Field(p => p.PaymentStatus).Type<NonNullType<StringType>>();
            descriptor.Field(p => p.Amount).Type<NonNullType<DecimalType>>();
            descriptor.Field(p => p.PaidAt).Type<DateTimeType>();
            descriptor.Field(p => p.CreatedAt).Type<NonNullType<DateTimeType>>();
            descriptor.Field(p => p.Tenant).Type<TenantType>();
        }
    }

}
