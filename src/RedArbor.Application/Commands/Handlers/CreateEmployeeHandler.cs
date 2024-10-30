using MediatR;
using RedArbor.Application.Commands.Commands;
using RedArbor.Domain.Models;
using RedArbor.Infrastructure.Repositories.Interfaces;


namespace RedArbor.Application.Commands.Handlers;

public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, ResponseResultDto>
{
    private readonly IEmployeeWriteRepository _repository;

    public CreateEmployeeHandler(IEmployeeWriteRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResponseResultDto> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var employee = new Employee
            {
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
            await _repository.AddAsync(employee);

            return new ResponseResultDto() { Success = true, Message = "Registro insertado correctamente" };
        }
        catch (Exception ex)
        {
            return new ResponseResultDto() { Success = false, Message = ex.Message };
        }
    }
}

