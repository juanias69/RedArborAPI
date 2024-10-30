using MediatR;
using RedArbor.Application.Dtos;
using RedArbor.Domain.Models;

namespace RedArbor.Application.Commands.Commands;

public record CreateEmployeeCommand(EmployeeDto employee) : IRequest<ResponseResultDto>;