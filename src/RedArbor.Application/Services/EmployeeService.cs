using MediatR;
using RedArbor.Application.Commands.Commands;
using RedArbor.Application.Dtos;
using RedArbor.Application.Interfaces;
using RedArbor.Application.Queries.Queries;
using RedArbor.Domain.Models;

namespace RedArbor.Application.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IMediator _mediator;

    public EmployeeService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync()
    {
        return await _mediator.Send(new GetEmployeesQuery());
    }

    public async Task<EmployeeDto> GetEmployeeByIdAsync(int id)
    {
        return await _mediator.Send(new GetEmployeeQuery(id));
    }

    public async Task<ResponseResultDto> CreateEmployeeAsync(EmployeeDto employee)
    {
        return await _mediator.Send(new CreateEmployeeCommand(employee));
    }

    public async Task<ResponseResultDto> UpdateEmployeeAsync(EmployeeDto employee)
    {
        return await _mediator.Send(new UpdateEmployeeCommand(employee));
    }

    public async Task<ResponseResultDto> DeleteEmployeeAsync(int id)
    {
        return await _mediator.Send(new DeleteEmployeeCommand(id));
    }


}
