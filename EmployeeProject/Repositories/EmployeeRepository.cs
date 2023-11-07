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
        public void CreateEmployee(Employee employee) => Create(employee);

        public IEnumerable<Employee> GetAllEmployees(bool trackChanges) => FindAll(trackChanges);

        public Employee? GetEmployeeById(int id, bool trackChanges)
        {
            return FindByCondition(a => a.EmployeeId.Equals(id), trackChanges);
        }

        public void UpdateEmployee(int id, Employee employee)
        {
            employee.EmployeeId = id;
            Update(employee);
        }
    }
}
