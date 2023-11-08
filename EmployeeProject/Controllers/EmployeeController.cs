using EmployeeProject.Entities.Dtos;
using EmployeeProject.Entities.Models;
using EmployeeProject.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public EmployeeController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees(bool trackChanges)
        {
            var employees = await _serviceManager.EmployeeService.GetAllEmployeesWithJuniors(trackChanges);
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id, bool trackChanges)
        {
            var employee = await _serviceManager.EmployeeService.GetEmployeeWithJuniors(id, trackChanges);
            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(employee);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeDtoForCreation employeeDto)
        {
            if (employeeDto == null)
            {
                return BadRequest("Employee object is null");
            }
            else
            {
                if (await _serviceManager.EmployeeService.CheckIdNumber(employeeDto.IdNumber))
                {
                    return BadRequest("Employee with this id number already exists");
                }
                if(employeeDto.SeniorId != null && employeeDto.SeniorId != 0)
                {
                    
                    if (await _serviceManager.EmployeeService.GetEmployeeById(employeeDto.SeniorId.Value, false) == null)
                    {
                        return BadRequest("Senior employee with this id does not exist");
                    }
                    
                }
                
                await _serviceManager.EmployeeService.CreateEmployee(employeeDto);
                return Ok();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] EmployeeDtoForUpdate employeeDto)
        {
            if (employeeDto == null)
            {
                return BadRequest("Employee object is null");
            }
            else
            {
                var employee = await _serviceManager.EmployeeService.GetEmployeeById(id, false);
                if (await _serviceManager.EmployeeService.CheckIdNumber(employeeDto.IdNumber) && employee.EmployeeId != id)
                {
                    return BadRequest("Employee with this id number already exists");
                }
                if (employeeDto.SeniorId != null && employeeDto.SeniorId != 0)
                {

                    if (await _serviceManager.EmployeeService.GetEmployeeById(employeeDto.SeniorId.Value, false) == null)
                    {
                        return BadRequest("Senior employee with this id does not exist");
                    }

                }
               

                await _serviceManager.EmployeeService.UpdateEmployee(id,employeeDto);
                return Ok();
            }
        }   
    }
}
