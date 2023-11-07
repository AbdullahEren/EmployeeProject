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

        public bool CheckIdNumber(string idNumber)
        {
            var employee = FindByCondition(a => a.IdNumber.Equals(idNumber), false);
            if (employee is null)
                return false;
            return true;
        }

        public void CreateEmployee(Employee employee) => Create(employee);

        public IEnumerable<Employee> GetAllEmployees(bool trackChanges) => FindAll(trackChanges);

        public Employee? GetEmployeeById(int id, bool trackChanges)
        {
            return FindByCondition(a => a.EmployeeId.Equals(id), trackChanges);
        }

        public List<int> GetJuniorIds(int id)
        {
            var seniorId = GetAllEmployees(false).FirstOrDefault(a => a.EmployeeId.Equals(id))?.SeniorId;

            if (seniorId.HasValue)
            {
                var juniors = GetAllEmployees(false).Where(a => a.SeniorId == seniorId).Select(a => a.EmployeeId).ToList();
                return juniors;
            }

            return new List<int>();
        }


        public void UpdateEmployee(int id, Employee employee)
        {
            employee.EmployeeId = id;
            Update(employee);
        }
    }
}
