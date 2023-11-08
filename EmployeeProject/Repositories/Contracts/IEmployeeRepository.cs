using EmployeeProject.Entities.Models;

namespace EmployeeProject.Repositories.Contracts
{
    public interface IEmployeeRepository : IRepositoryBase<Employee>
    {
        Task<IEnumerable<Employee>> GetAllEmployees(bool trackChanges);
        Task<Employee?> GetEmployeeById(int id, bool trackChanges);
        Task CreateEmployee(Employee employee);
        Task UpdateEmployee(int id, Employee employee);
        Task<bool> CheckIdNumber(string idNumber);
        Task<List<int>> GetJuniorIds(int id, bool trackChanges);

    }
}
