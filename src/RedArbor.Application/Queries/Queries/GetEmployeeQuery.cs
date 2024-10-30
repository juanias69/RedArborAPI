using MediatR;
using RedArbor.Application.Dtos;

namespace RedArbor.Application.Queries.Queries;

public record GetEmployeeQuery(int Id) : IRequest<EmployeeDto>;