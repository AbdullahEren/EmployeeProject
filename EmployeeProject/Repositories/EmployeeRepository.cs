using EmployeeProject.Entities.Models;
using EmployeeProject.Repositories.Contracts;

namespace EmployeeProject.Repositories
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public async Task CreateEmployee(Employee employee) => await CreateAsync(employee);

        public IEnumerable<Employee> GetAllEmployees(bool trackChanges) => FindAll(trackChanges);

        public Employee? GetEmployeeById(int id, bool trackChanges)
        {
            return FindByCondition(a => a.EmployeeId.Equals(id), trackChanges);
        }

        public async Task UpdateEmployee(Employee employee) => await UpdateAsync(employee);
    }
}
