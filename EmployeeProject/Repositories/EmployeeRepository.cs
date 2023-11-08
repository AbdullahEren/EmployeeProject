using EmployeeProject.Entities.Models;
using EmployeeProject.Repositories.Contracts;
using Microsoft.AspNetCore.CookiePolicy;

namespace EmployeeProject.Repositories
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<bool> CheckIdNumber(string idNumber)
        {
            var employee = await FindByCondition(a => a.IdNumber.Equals(idNumber), false);
            if (employee.SingleOrDefault() is null)
                return false;
            return true;
        }

        public async Task CreateEmployee(Employee employee) => await Create(employee);

        public async Task<IEnumerable<Employee>> GetAllEmployees(bool trackChanges) => await FindAll(trackChanges);

        public async Task<Employee?> GetEmployeeById(int id, bool trackChanges)
        {
            var employee = await FindByCondition(a => a.EmployeeId.Equals(id), trackChanges);
            return employee.SingleOrDefault();
        }

        public async Task<List<int>> GetJuniorIds(int id,bool trackChanges)
        {
            var seniorId = await FindByCondition(a => a.SeniorId.Equals(id), trackChanges);
            return seniorId.Select(a => a.EmployeeId).ToList();
        }

        public async Task UpdateEmployee(int id, Employee employee)
        {
            employee.EmployeeId = id;
            await Update(employee);
        }
    }
}
