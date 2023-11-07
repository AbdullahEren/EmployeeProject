using EmployeeProject.Entities.Models;

namespace EmployeeProject.Repositories.Contracts
{
    public interface IEmployeeRepository : IRepositoryBase<Employee>
    {
        IEnumerable<Employee> GetAllEmployees(bool trackChanges);
        Employee? GetEmployeeById(int id, bool trackChanges);
        void CreateEmployee(Employee employee);
        void UpdateEmployee(int id, Employee employee);

    }
}
