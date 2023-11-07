using EmployeeProject.Repositories.Contracts;

namespace EmployeeProject.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _context;
        private Lazy<IEmployeeRepository> _employeeRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _context = repositoryContext;
            _employeeRepository = new Lazy<IEmployeeRepository>(() => new EmployeeRepository(_context));
        }

        public IEmployeeRepository Employee => _employeeRepository.Value;

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
