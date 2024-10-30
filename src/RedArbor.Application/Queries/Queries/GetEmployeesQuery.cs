using System;
using MediatR;
using RedArbor.Application.Dtos;
using RedArbor.Domain.Models;

namespace RedArbor.Application.Queries.Queries;

public record GetEmployeesQuery : IRequest<IEnumerable<EmployeeDto>>;
