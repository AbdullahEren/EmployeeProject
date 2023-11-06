using EmployeeProject.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EmployeeProject.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class, new()
    {
        private readonly RepositoryContext _context;

        protected RepositoryBase(RepositoryContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }




        public IEnumerable<T> FindAll(bool trackChanges)
        {
            return  trackChanges
                ? _context.Set<T>()
                : _context.Set<T>().AsNoTracking();
        }
        public T? FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return trackChanges
                ?  _context.Set<T>().Where(expression).SingleOrDefault()
                :  _context.Set<T>().Where(expression).AsNoTracking().SingleOrDefault();
        }

    }
}
