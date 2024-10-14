using HotChocolate;
using backend.Models;
using backend.Database;

namespace backend.GraphQL.Mutations
{
    public class PaymentMutations
    {
        public async Task<Payment> CreatePaymentAsync([Service] AppDbContext context, Payment payment)
        {
            context.Payments.Add(payment);
            await context.SaveChangesAsync();
            return payment;
        }

        public async Task<Payment> UpdatePaymentAsync([Service] AppDbContext context, Payment payment)
        {
            context.Payments.Update(payment);
            await context.SaveChangesAsync();
            return payment;
        }

        public async Task<bool> DeletePaymentAsync([Service] AppDbContext context, int paymentId)
        {
            var payment = await context.Payments.FindAsync(paymentId);
            if (payment == null) return false;

            context.Payments.Remove(payment);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
