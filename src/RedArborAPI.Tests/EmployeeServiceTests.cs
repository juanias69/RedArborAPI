
using FluentAssertions;
using Moq;
using RedArbor.Application.Dtos;
using RedArbor.Application.Services;
using MediatR;
using RedArbor.Application.Interfaces;
using RedArbor.Domain.Models;

namespace RedArborAPI.Tests;

public class EmployeeServiceTests
{
    private readonly IEmployeeService _employeeService;
    private readonly Mock<IMediator> _mediatorMock;

    public EmployeeServiceTests()
    {
        _mediatorMock = new Mock<IMediator>();
        _employeeService = new EmployeeService(_mediatorMock.Object);
    }
    [Fact]
    public async Task GetAllEmployeesAsync_ShouldReturnAllEmployees()
    {
        // Arrange
        var employees = new List<EmployeeDto>
            {
                new EmployeeDto { CompanyId = 1, Username = "test1" },
                new EmployeeDto { CompanyId = 2, Username = "test2" }
            };

        _mediatorMock.Setup(m => m.Send(It.IsAny<IRequest<IEnumerable<EmployeeDto>>>(), It.IsAny<CancellationToken>()))
                     .ReturnsAsync(employees);

        // Act
        var result = await _employeeService.GetAllEmployeesAsync();

        // Assert
        result.Should().HaveCount(2);
        result.Should().Contain(employees);
    }

    [Fact]
    public async Task GetEmployeeByIdAsync_ShouldReturnEmployee_WhenEmployeeExists()
    {
        // Arrange
        var employee = new EmployeeDto { CompanyId = 1, Username = "test1" };

        _mediatorMock.Setup(m => m.Send(It.IsAny<IRequest<EmployeeDto>>(), It.IsAny<CancellationToken>()))
                     .ReturnsAsync(employee);

        // Act
        var result = await _employeeService.GetEmployeeByIdAsync(1);

        // Assert
        result.Should().NotBeNull();
        result.Username.Should().Be("test1");
    }

    [Fact]
    public async Task CreateEmployeeAsync_ShouldReturnSuccessResult_WhenEmployeeIsCreated()
    {
        // Arrange
        var newEmployee = new EmployeeDto { CompanyId = 1, Username = "test1" };
        var response = new ResponseResultDto { Success = true, Message = "Employee created successfully" };

        _mediatorMock.Setup(m => m.Send(It.IsAny<IRequest<ResponseResultDto>>(), It.IsAny<CancellationToken>()))
                     .ReturnsAsync(response);

        // Act
        var result = await _employeeService.CreateEmployeeAsync(newEmployee);

        // Assert
        result.Should().NotBeNull();
        result.Success.Should().BeTrue();
        result.Message.Should().Be("Employee created successfully");
    }

    [Fact]
    public async Task UpdateEmployeeAsync_ShouldReturnSuccessResult_WhenEmployeeIsUpdated()
    {
        // Arrange
        var updatedEmployee = new EmployeeDto { CompanyId = 1, Username = "test1updated" };
        var response = new ResponseResultDto { Success = true, Message = "Employee updated successfully" };

        _mediatorMock.Setup(m => m.Send(It.IsAny<IRequest<ResponseResultDto>>(), It.IsAny<CancellationToken>()))
                     .ReturnsAsync(response);

        // Act
        var result = await _employeeService.UpdateEmployeeAsync(updatedEmployee);

        // Assert
        result.Should().NotBeNull();
        result.Success.Should().BeTrue();
        result.Message.Should().Be("Employee updated successfully");
    }

    [Fact]
    public async Task DeleteEmployeeAsync_ShouldReturnSuccessResult_WhenEmployeeIsDeleted()
    {
        // Arrange
        var response = new ResponseResultDto { Success = true, Message = "Employee deleted successfully" };

        _mediatorMock.Setup(m => m.Send(It.IsAny<IRequest<ResponseResultDto>>(), It.IsAny<CancellationToken>()))
                     .ReturnsAsync(response);

        // Act
        var result = await _employeeService.DeleteEmployeeAsync(1);

        // Assert
        result.Should().NotBeNull();
        result.Success.Should().BeTrue();
        result.Message.Should().Be("Employee deleted successfully");
    }
}
