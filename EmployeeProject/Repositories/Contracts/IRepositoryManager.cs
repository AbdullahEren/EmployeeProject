namespace EmployeeProject.Repositories.Contracts
{
    public interface IRepositoryManager
    {
        IEmployeeRepository Employee { get; }

        Task Save();

    }
}
