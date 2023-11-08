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

        public async Task Create(T entity)
        {
           await _context.Set<T>().AddAsync(entity);
           
        }

        public async Task Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }




        public async Task<IEnumerable<T>> FindAll(bool trackChanges)
        {
            return  trackChanges
                ? await _context.Set<T>().ToListAsync()
                : await _context.Set<T>().AsNoTracking().ToListAsync();
        }
        public async Task<IEnumerable<T>> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return trackChanges
                ?  await _context.Set<T>().Where(expression).ToListAsync()
                :  await _context.Set<T>().Where(expression).AsNoTracking().ToListAsync();
        }

    }
}
