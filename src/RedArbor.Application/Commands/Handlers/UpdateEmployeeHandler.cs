
using MediatR;
using RedArbor.Application.Commands.Commands;
using RedArbor.Application.Dtos;
using RedArbor.Domain.Models;
using RedArbor.Infrastructure.Repositories.Interfaces;

namespace RedArbor.Application.Commands.Handlers;

public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeCommand, ResponseResultDto>
{
    private readonly IEmployeeWriteRepository _repository;

    public UpdateEmployeeHandler(IEmployeeWriteRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResponseResultDto> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (request.employee.Id == null)
                return new ResponseResultDto() { Success = false, Message = "El ID del empleado no puede ser nulo." };

            var employee = new Employee
            {
                Id = (int)request.employee.Id,
                CompanyId = request.employee.CompanyId,
                CreatedOn = request.employee.CreatedOn,
                DeletedOn = request.employee.DeletedOn,
                UpdatedOn = request.employee.UpdatedOn,
                Fax = request.employee.Fax,
                Lastlogin = request.employee.Lastlogin,
                Name = request.employee.Name,
                Telephone = request.employee.Telephone,
                Email = request.employee.Email,
                Password = request.employee.Password,
                PortalId = request.employee.PortalId,
                RoleId = request.employee.RoleId,
                StatusId = request.employee.StatusId,
                Username = request.employee.Username
            };
            await _repository.UpdateAsync(employee);

            return new ResponseResultDto() { Success = true, Message = "Registro actualizado correctamente" };
        }
        catch (Exception ex)
        {
            return new ResponseResultDto() { Success = false, Message = ex.Message };
        }
    }
}

