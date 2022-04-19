using Employees.Api.Dtos;
using Employees.Api.Models;

namespace Employees.Api.Services
{
    public interface IEmployeeServices
    {
        Task<List<Employee>> GetEmployees();

        Task<bool> AddEmployee(EmployeeDto employeeDto);
    }
}
