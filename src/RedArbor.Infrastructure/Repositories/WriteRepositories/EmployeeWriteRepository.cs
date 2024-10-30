using RedArbor.Domain.Models;
using RedArbor.Infrastructure.Data;
using RedArbor.Infrastructure.Repositories.Interfaces;

namespace RedArbor.Infrastructure.Repositories.WriteRepositories;

public class EmployeeWriteRepository : IEmployeeWriteRepository
{
    private readonly ApplicationDbContext _context;

    public EmployeeWriteRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Employee employee)
    {
        await _context.Employees.AddAsync(employee);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Employee employee)
    {
        _context.Employees.Update(employee);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var employee = await _context.Employees.FindAsync(id);
        if (employee != null)
        {
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }
    }
}
