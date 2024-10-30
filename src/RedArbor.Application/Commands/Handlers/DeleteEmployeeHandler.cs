using System;
using MediatR;
using RedArbor.Application.Commands.Commands;
using RedArbor.Domain.Models;
using RedArbor.Infrastructure.Repositories.Interfaces;

namespace RedArbor.Application.Commands.Handlers;

public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeCommand, ResponseResultDto>
{
    private readonly IEmployeeWriteRepository _repository;

    public DeleteEmployeeHandler(IEmployeeWriteRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResponseResultDto> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _repository.DeleteAsync(request.Id);
            return new ResponseResultDto() { Success = true, Message = "Registro eliminado correctamente" };
        }
        catch (Exception ex)
        {
            return new ResponseResultDto() { Success = false, Message = ex.Message };
        }
    }

}
