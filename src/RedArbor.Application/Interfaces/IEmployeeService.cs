
using RedArbor.Application.Dtos;
using RedArbor.Domain.Models;

namespace RedArbor.Application.Interfaces;

public interface IEmployeeService
{
    Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync();
    Task<EmployeeDto> GetEmployeeByIdAsync(int id);
    Task<ResponseResultDto> CreateEmployeeAsync(EmployeeDto employee);
    Task<ResponseResultDto> UpdateEmployeeAsync(EmployeeDto employee);
    Task<ResponseResultDto> DeleteEmployeeAsync(int id);
}
