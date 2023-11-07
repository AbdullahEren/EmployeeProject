using EmployeeProject.Entities.Models;
using EmployeeProject.Repositories.Contracts;
using EmployeeProject.Services.Contracts;

namespace EmployeeProject.Services
{
    public class EmployeeManager : IEmployeeService
    {
        private readonly IRepositoryManager _manager;

        public EmployeeManager(IRepositoryManager manager)
        {
            _manager = manager;
        }


        public IEnumerable<Employee> GetAllEmployees(bool trackChanges)
        {
            return _manager.Employee.GetAllEmployees(trackChanges);
        }

        public Employee? GetEmployeeById(int id, bool trackChanges)
        {
            var employee = _manager.Employee.GetEmployeeById(id, trackChanges);
            if (employee is null)
                throw new Exception("Employee can not found.");
            return employee;
        }
        public void CreateEmployee(Employee employee)
        {
            if (employee.SeniorId == employee.EmployeeId)
            {
                throw new Exception("Bir çalışan kendisini üst çalışan olarak atayamaz.");
            }
            _manager.Employee.CreateEmployee(employee);
            _manager.Save();
        }

        public void UpdateEmployee(Employee employee)
        {

            if (employee.SeniorId == employee.EmployeeId)
            {
                throw new Exception("Bir çalışan kendisini üst çalışan olarak atayamaz.");
            }
            _manager.Employee.UpdateEmployee(employee);
            _manager.Save();
        }
    }
}
