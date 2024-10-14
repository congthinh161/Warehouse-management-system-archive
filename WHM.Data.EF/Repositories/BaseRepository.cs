using Whm.Data.EF.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Whm.Data.EF.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public virtual async Task<T> GetById(Guid id)
        {
            return await _context.Set<T>().FindAsync(id).ConfigureAwait(false);
        }

        public virtual async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity).ConfigureAwait(false);
        }

        public virtual void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public virtual async Task<IEnumerable<T>> All()
        {
            return await _context.Set<T>().ToListAsync().ConfigureAwait(false);
        }

        public virtual async Task<IEnumerable<T>> FindMultiple(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync().ConfigureAwait(false);
        }

        public virtual async Task<T> FindObject(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(predicate).ConfigureAwait(false);
        }

        public virtual async Task<int> Count()
        {
            return await _context.Set<T>().CountAsync().ConfigureAwait(false);
        }
    }
}
