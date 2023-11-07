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
        public IActionResult GetAllEmployees(bool trackChanges)
        {
            var employees = _serviceManager.EmployeeService.GetAllEmployees(trackChanges);
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id, bool trackChanges)
        {
            var employee = _serviceManager.EmployeeService.GetEmployeeById(id, trackChanges);
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
        public IActionResult CreateEmployee([FromBody] EmployeeDtoForCreation employeeDto)
        {
            if (employeeDto == null)
            {
                return BadRequest("Employee object is null");
            }
            else
            {
                _serviceManager.EmployeeService.CreateEmployee(employeeDto);
                return Ok();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, [FromBody] EmployeeDtoForUpdate employeeDto)
        {
            if (employeeDto == null)
            {
                return BadRequest("Employee object is null");
            }
            else
            {

                _serviceManager.EmployeeService.UpdateEmployee(id,employeeDto);
                return Ok();
            }
        }   
    }
}
