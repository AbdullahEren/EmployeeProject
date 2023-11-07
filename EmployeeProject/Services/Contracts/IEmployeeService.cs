using EmployeeProject.Entities.Dtos;
using EmployeeProject.Entities.Models;

namespace EmployeeProject.Services.Contracts
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAllEmployees(bool trackChanges);
        Employee? GetEmployeeById(int id, bool trackChanges);
        void CreateEmployee(EmployeeDtoForCreation employeeDto);
        void UpdateEmployee(int id,EmployeeDtoForUpdate employeeDto);
    }
}
