using System;
using RedArbor.Domain.Models;

namespace RedArbor.Infrastructure.Repositories.Interfaces;

public interface IEmployeeReadRepository
{
    Task<IEnumerable<Employee>> GetAllAsync();
    Task<Employee> GetByIdAsync(int id);
}
