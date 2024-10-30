using MediatR;
using RedArbor.Domain.Models;

namespace RedArbor.Application.Commands.Commands;

public record DeleteEmployeeCommand(int Id) : IRequest<ResponseResultDto>;
