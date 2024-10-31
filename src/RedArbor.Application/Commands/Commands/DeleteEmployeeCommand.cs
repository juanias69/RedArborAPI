using MediatR;
using RedArbor.Application.Dtos;


namespace RedArbor.Application.Commands.Commands;

public record DeleteEmployeeCommand(int Id) : IRequest<ResponseResultDto>;
