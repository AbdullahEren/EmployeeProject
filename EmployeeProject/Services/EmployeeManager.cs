using AutoMapper;
using EmployeeProject.Entities.Dtos;
using EmployeeProject.Entities.Models;
using EmployeeProject.Repositories.Contracts;
using EmployeeProject.Services.Contracts;

namespace EmployeeProject.Services
{
    public class EmployeeManager : IEmployeeService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public EmployeeManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
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
        public void CreateEmployee(EmployeeDtoForCreation employeeDto)
        {
            if (employeeDto.SeniorId == employeeDto.EmployeeId)
            {
                throw new Exception("An employee cannot appoint yourself as a superior employee.");
            }
            if(CheckIdNumber(employeeDto.IdNumber) == true)
            {
                throw new Exception("This id number is already exist.");
            }
            var employee = _mapper.Map<Employee>(employeeDto);
            _manager.Employee.CreateEmployee(employee);
            _manager.Save();
        }

        public void UpdateEmployee(int id, EmployeeDtoForUpdate employeeDto)
        {
            var entity = _manager.Employee.GetEmployeeById(id, false);
            if (entity is null)
                throw new Exception("Employee can not found.");

            if (employeeDto.SeniorId == entity.EmployeeId)
            {
                throw new Exception("An employee cannot appoint yourself as a superior employee.");
            }
            if (CheckIdNumber(employeeDto.IdNumber) == true)
            {
                throw new Exception("This id number is already exist.");
            }

            var employee = _mapper.Map<Employee>(employeeDto);
            _manager.Employee.UpdateEmployee(id,employee);
            _manager.Save();
        }

        public List<int> GetJuniorIds(int id)
        {
            return _manager.Employee.GetJuniorIds(id);
        }

        public bool CheckIdNumber(string idNumber)
        {
            return _manager.Employee.CheckIdNumber(idNumber);
        }
    }
}
