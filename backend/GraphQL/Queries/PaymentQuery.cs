using backend.Database;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.GraphQL.Queries
{
    public class PaymentQuery
    {
        private readonly AppDbContext _context;

        // Constructor to inject AppDbContext
        public PaymentQuery(AppDbContext context)
        {
            _context = context;
        }

        // Resolver to get a list of payments
        public async Task<IEnumerable<Payment>> GetPayments()
        {
            return await _context.Payments.ToListAsync();
        }

        // Resolver to get a payment by ID
        public async Task<Payment?> GetPaymentById(int id)
        {
            return await _context.Payments.FindAsync(id);
        }
    }
}
