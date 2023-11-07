using EmployeeProject.Entities.Models;

namespace EmployeeProject.Services.Contracts
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAllEmployees(bool trackChanges);
        Employee? GetEmployeeById(int id, bool trackChanges);
        void CreateEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
    }
}
