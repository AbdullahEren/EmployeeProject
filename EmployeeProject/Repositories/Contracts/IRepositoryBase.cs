using System.Linq.Expressions;

namespace EmployeeProject.Repositories.Contracts
{
    public interface IRepositoryBase<T>
    {
        Task<IEnumerable<T>> FindAll(bool trackChanges);
        Task<IEnumerable<T>> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
        Task Create(T entity);
        Task Update(T entity);
    }
}
