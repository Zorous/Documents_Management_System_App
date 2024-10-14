using backend.Database;
using backend.Models; 
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend.GraphQL.Queries
{
    public class DepartmentQuery
    {
        private readonly AppDbContext _context;

        public DepartmentQuery(AppDbContext context)
        {
            _context = context;
        }

        // Method to get a single department by ID
        public async Task<Department?> GetDepartmentById(int id)
        {
            return await _context.Departments.FindAsync(id);
        }

        // Method to get all departments
        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await _context.Departments.ToListAsync();
        }
    }
}
