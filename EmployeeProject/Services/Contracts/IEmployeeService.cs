using EmployeeProject.Entities.Dtos;
using EmployeeProject.Entities.Models;

namespace EmployeeProject.Services.Contracts
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDtoForRead>> GetAllEmployees(bool trackChanges);
        Task<EmployeeDtoForRead> GetEmployeeById(int id, bool trackChanges);
        Task CreateEmployee(EmployeeDtoForCreation employeeDto);
        Task UpdateEmployee(int id,EmployeeDtoForUpdate employeeDto);
        Task<List<int>> GetJuniorIds(int id, bool trackChanges);
        Task<bool> CheckIdNumber(string idNumber);
        Task<EmployeeDtoForRead> GetEmployeeWithJuniors(int id, bool trackChanges);
        Task<IEnumerable<EmployeeDtoForRead>> GetAllEmployeesWithJuniors(bool trackChanges);
    }
}
