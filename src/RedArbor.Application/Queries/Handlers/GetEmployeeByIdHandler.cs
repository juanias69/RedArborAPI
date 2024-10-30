
using System;
using MediatR;
using RedArbor.Application.Dtos;
using RedArbor.Application.Queries.Queries;
using RedArbor.Infrastructure.Repositories.Interfaces;

namespace RedArbor.Application.Queries.Handlers;

public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeQuery, EmployeeDto>
{
    private readonly IEmployeeReadRepository _repository;

    public GetEmployeeByIdHandler(IEmployeeReadRepository repository)
    {
        _repository = repository;
    }

    public async Task<EmployeeDto> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
    {
        try
        {
            EmployeeDto employee = new();
            var employeeResult = await _repository.GetByIdAsync(request.Id);
            if (employeeResult != null)
            {
                employee.Id = employeeResult.Id;
                employee.CompanyId = employeeResult.CompanyId;
                employee.CreatedOn = employeeResult.CreatedOn;
                employee.DeletedOn = employeeResult.DeletedOn;
                employee.Email = employeeResult.Email;
                employee.Fax = employeeResult.Fax;
                employee.Name = employeeResult.Name;
                employee.Lastlogin = employeeResult.Lastlogin;
                employee.Password = employeeResult.Password;
                employee.PortalId = employeeResult.PortalId;
                employee.RoleId = employeeResult.RoleId;
                employee.StatusId = employeeResult.StatusId;
                employee.Telephone = employeeResult.Telephone;
                employee.UpdatedOn = employeeResult.UpdatedOn;
                employee.Username = employeeResult.Username;
            }
            return employee;
        }
        catch (Exception ex)
        {
            throw new KeyNotFoundException("Error al obtener la informacion", ex.InnerException);
        }
    }
}
