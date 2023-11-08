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


        public async Task<IEnumerable<EmployeeDtoForRead>> GetAllEmployees(bool trackChanges)
        {
            var employees = await _manager.Employee.GetAllEmployees(trackChanges);
            var employeesDto = _mapper.Map<IEnumerable<EmployeeDtoForRead>>(employees);
            return employeesDto;
        }

        public async Task<IEnumerable<EmployeeDtoForRead>> GetAllEmployeesWithJuniors(bool trackChanges)
        {
            var employees = await _manager.Employee.GetAllEmployees(trackChanges);
            var employeesDtoForRead = new List<EmployeeDtoForRead>();

            foreach (var employee in employees)
            {
                var juniorIds = await _manager.Employee.GetJuniorIds(employee.EmployeeId, trackChanges);
                var juniors = new List<EmployeeDtoForRead>();

                foreach (var juniorId in juniorIds)
                {
                    var junior = await _manager.Employee.GetEmployeeById(juniorId, trackChanges);
                    var juniorDto = _mapper.Map<EmployeeDtoForRead>(junior);
                    if (juniorDto != null)
                    {
                        juniors.Add(juniorDto);
                    }
                }

                employeesDtoForRead.Add(new EmployeeDtoForRead
                {
                    EmployeeId = employee.EmployeeId,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    IdNumber = employee.IdNumber,
                    SeniorId = employee.SeniorId,
                    Juniors = juniors
                });
            }

            return employeesDtoForRead;
        }


        public async Task<EmployeeDtoForRead> GetEmployeeById(int id, bool trackChanges)
        {
            var employee = await _manager.Employee.GetEmployeeById(id, trackChanges);
            var employeeDto = _mapper.Map<EmployeeDtoForRead>(employee);
            
            return employeeDto;
        }
        public async Task<EmployeeDtoForRead> GetEmployeeWithJuniors(int id, bool trackChanges)
        {
            var employee = await _manager.Employee.GetEmployeeById(id, trackChanges);
            if (employee is null)
                throw new Exception("Employee cannot be found.");

            var juniorIds = await _manager.Employee.GetJuniorIds(employee.EmployeeId, trackChanges);
            var juniors = new List<EmployeeDtoForRead>();

            foreach (var juniorId in juniorIds)
            {
                var junior = await _manager.Employee.GetEmployeeById(juniorId, trackChanges);
                var juniorDto = _mapper.Map<EmployeeDtoForRead>(junior);
                if (juniorDto != null)
                {
                    juniors.Add(juniorDto);
                }
            }

            return new EmployeeDtoForRead
            {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                IdNumber = employee.IdNumber,
                SeniorId = employee.SeniorId,
                Juniors = juniors
            };
        }

        public async Task CreateEmployee(EmployeeDtoForCreation employeeDto)
        {
    
            var employee = _mapper.Map<Employee>(employeeDto);
            if (employeeDto.SeniorId == 0)
            {
                employee.SeniorId = null;
            }
            await _manager.Employee.CreateEmployee(employee);
            await _manager.Save();
            
        }

        public async Task UpdateEmployee(int id, EmployeeDtoForUpdate employeeDto)
        {
            var entity = await _manager.Employee.GetEmployeeById(id, false);
            if (entity is null)
                throw new Exception("Employee can not found.");

            if (employeeDto.SeniorId == entity.EmployeeId)
            {
                throw new Exception("An employee cannot appoint yourself as a senior employee.");
            }
            
            var employee = _mapper.Map<Employee>(employeeDto);
            if (employeeDto.SeniorId == 0)
            {
                employee.SeniorId = null;
            }

            await _manager.Employee.UpdateEmployee(id,employee);
            await _manager.Save();
        }

        public async Task<List<int>> GetJuniorIds(int id, bool trackChanges)
        {
            return await _manager.Employee.GetJuniorIds(id,trackChanges);
        }

        public async Task<bool> CheckIdNumber(string idNumber)
        {
            return await _manager.Employee.CheckIdNumber(idNumber);
        }
    }
}
