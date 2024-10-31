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
        var existingEmployee = await _context.Employees.FindAsync(employee.Id);

        if (existingEmployee != null)
        {
            existingEmployee.CompanyId = employee.CompanyId;
            existingEmployee.CreatedOn = employee.CreatedOn;
            existingEmployee.DeletedOn = employee.DeletedOn;
            existingEmployee.Email = employee.Email;
            existingEmployee.Fax = employee.Fax;
            existingEmployee.Name = employee.Name;
            existingEmployee.Lastlogin = employee.Lastlogin;
            existingEmployee.Password = employee.Password;
            existingEmployee.PortalId = employee.PortalId;
            existingEmployee.RoleId = employee.RoleId;
            existingEmployee.StatusId = employee.StatusId;
            existingEmployee.Telephone = employee.Telephone;
            existingEmployee.UpdatedOn = employee.UpdatedOn;
            existingEmployee.Username = employee.Username;
            await _context.SaveChangesAsync();
        }
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
