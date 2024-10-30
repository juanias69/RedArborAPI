using System;
using MediatR;
using RedArbor.Application.Dtos;
using RedArbor.Application.Queries.Queries;
using RedArbor.Domain.Models;
using RedArbor.Infrastructure.Repositories.Interfaces;

namespace RedArbor.Application.Queries.Handlers;

public class GetEmployeesHandler : IRequestHandler<GetEmployeesQuery, IEnumerable<EmployeeDto>>
{
    private readonly IEmployeeReadRepository _repository;

    public GetEmployeesHandler(IEmployeeReadRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<EmployeeDto>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            List<EmployeeDto> ltEmployees = new();
            var employees = await _repository.GetAllAsync();

            if (employees != null)
            {
                ltEmployees = employees.Select(x => new EmployeeDto
                {
                    Id = x.Id,
                    CompanyId = x.CompanyId,
                    CreatedOn = x.CreatedOn,
                    DeletedOn = x.DeletedOn,
                    Email = x.Email,
                    Fax = x.Fax,
                    Name = x.Name,
                    Lastlogin = x.Lastlogin,
                    Password = x.Password,
                    PortalId = x.PortalId,
                    RoleId = x.RoleId,
                    StatusId = x.StatusId,
                    Telephone = x.Telephone,
                    UpdatedOn = x.UpdatedOn,
                    Username = x.Username
                }).ToList();
            }

            return ltEmployees;
        }
        catch (Exception ex)
        {
            throw new KeyNotFoundException("Error al obtener la informacion", ex.InnerException);
        }
    }
}
