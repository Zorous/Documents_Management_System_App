using backend.Database;
using backend.Models;


namespace backend.GraphQL.Mutations
{
    public class DepartmentMutations
{
    public async Task<Department> CreateDepartmentAsync(Department input, [Service] AppDbContext dbContext)
    {
        dbContext.Departments.Add(input);
        await dbContext.SaveChangesAsync();
        return input;
    }

    public async Task<Department> UpdateDepartmentAsync(int departmentId, Department input, [Service] AppDbContext    dbContext)
    {
        var department = await dbContext.Departments.FindAsync(departmentId);
        if (department == null) throw new Exception("Department not found");

        department.DepartmentName = input.DepartmentName;
        department.CreatedAt = input.CreatedAt; // Depending on your logic, you might not want to update CreatedAt

        await dbContext.SaveChangesAsync();
        return department;
    }

    public async Task<bool> DeleteDepartmentAsync(int departmentId, [Service] AppDbContext dbContext)
    {
        var department = await dbContext.Departments.FindAsync(departmentId);
        if (department == null) throw new Exception("Department not found");

        dbContext.Departments.Remove(department);
        await dbContext.SaveChangesAsync();
        return true;
    }
}
}