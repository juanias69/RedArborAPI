using MediatR;
using RedArbor.Application.Dtos;
using RedArbor.Domain.Models;

namespace RedArbor.Application.Commands.Commands;

public record UpdateEmployeeCommand(EmployeeDto employee) : IRequest<ResponseResultDto>;