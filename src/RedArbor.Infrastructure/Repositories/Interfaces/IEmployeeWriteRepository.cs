using RedArbor.Domain.Models;
using System.Threading.Tasks;

namespace RedArbor.Infrastructure.Repositories.Interfaces;

public interface IEmployeeWriteRepository
{
    Task AddAsync(Employee employee);
    Task UpdateAsync(Employee employee);
    Task DeleteAsync(int id);
}