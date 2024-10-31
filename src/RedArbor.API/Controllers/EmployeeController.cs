using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RedArbor.Application.Dtos;
using RedArbor.Application.Interfaces;

namespace RedArbor.API.Controllers
{
    [Route("api/redarbor")]
    [ApiController]
    // [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetAllEmployees()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDto>> GetEmployeeById(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseResultDto>> CreateEmployee([FromBody] EmployeeDto employeeDto)
        {
            var result = await _employeeService.CreateEmployeeAsync(employeeDto);
            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] EmployeeDto employeeDto)
        {
            employeeDto.Id = id;
            var result = await _employeeService.UpdateEmployeeAsync(employeeDto);
            if (!result.Success)
                return NotFound(result.Message);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var result = await _employeeService.DeleteEmployeeAsync(id);
            if (!result.Success)
                return NotFound(result.Message);

            return Ok(result);
        }

    }
}
