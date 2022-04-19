using System.Net;
using Employees.Api.Dtos;
using Employees.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Employees.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeServices _services;

        public EmployeesController(IEmployeeServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _services.GetEmployees();
            if (!employees.Any())
            {
                return NotFound("Employees not found");
            }

            return Ok(employees);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeDto employeeDto)
        {
            var response = await _services.AddEmployee(employeeDto);

            return !response
                ? StatusCode(StatusCodes.Status500InternalServerError, new { Message = "Error creating employee" })
                : Ok(new { Message = "Employee created", HttpCode = HttpStatusCode.OK });
        }
    }
}
