using EmployeeProject.Entities.Models;
using EmployeeProject.Repositories.Contracts;
using EmployeeProject.Services.Contracts;

namespace EmployeeProject.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IEmployeeService> _employeeService;

        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _employeeService = new Lazy<IEmployeeService>(() => new EmployeeManager(repositoryManager));
        }

        public IEmployeeService EmployeeService => _employeeService.Value;
    }
}
