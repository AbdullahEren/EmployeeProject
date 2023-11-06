using EmployeeProject.Repositories.Contracts;

namespace EmployeeProject.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private IEmployeeRepository _employeeRepository;

        public RepositoryManager(RepositoryContext context, IEmployeeRepository employeeRepository)
        {
            _context = context;
            _employeeRepository = employeeRepository;
        }

        public IEmployeeRepository Employee => _employeeRepository;

    }
}
