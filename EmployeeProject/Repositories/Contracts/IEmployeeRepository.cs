using EmployeeProject.Entities.Models;

namespace EmployeeProject.Repositories.Contracts
{
    public interface IEmployeeRepository : IRepositoryBase<Employee>
    {
        IEnumerable<Employee> GetAllEmployees(bool trackChanges);
        Employee? GetEmployeeById(int id, bool trackChanges);
        Task CreateEmployee(Employee employee);
        Task UpdateEmployee(Employee employee);

    }
}
