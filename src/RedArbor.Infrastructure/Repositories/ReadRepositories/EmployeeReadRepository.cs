using System;
using System.Data;
using Dapper;
using RedArbor.Domain.Models;
using RedArbor.Infrastructure.Repositories.Interfaces;

namespace RedArbor.Infrastructure.Repositories.ReadRepositories;

public class EmployeeReadRepository : IEmployeeReadRepository
{
    private readonly IDbConnection _dbConnection;

    public EmployeeReadRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<IEnumerable<Employee>> GetAllAsync()
    {
        var query = "SELECT * FROM Employees";
        return await _dbConnection.QueryAsync<Employee>(query);
    }

    public async Task<Employee> GetByIdAsync(int id)
    {
        var query = "SELECT * FROM Employees WHERE Id = @Id";
        return await _dbConnection.QueryFirstOrDefaultAsync<Employee>(query, new { Id = id });
    }
}
