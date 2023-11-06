using System.Linq.Expressions;

namespace EmployeeProject.Repositories.Contracts
{
    public interface IRepositoryBase<T>
    {
        IEnumerable<T> FindAll(bool trackChanges);
        T? FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
    }
}
