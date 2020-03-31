using Microsoft.EntityFrameworkCore;
using NettrimCh.Api.DataAccess.Contracts.Models;
using NettrimCh.Api.DataAccess.Contracts.Repositories.GenericRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NettrimCh.Api.DataAccess.Repositories.GenericRepository
{
    public abstract class GenericRepository<T>: IGenericRepository<T> where T : class
    {
        public NettrimDbContext _context;
        public DbSet<T> _table;

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _table.ToListAsync().ConfigureAwait(false);
        }

        public virtual async Task<T> GetById(object id)
        {
            return await _table.FindAsync(id).ConfigureAwait(false);
        }

        public virtual async Task Add(T obj)
        {
            await Task.Run(() => _table.Add(obj)).ConfigureAwait(false);
        }

        public virtual async Task Update(T obj)
        {
            await Task.Run(() => _table.Attach(obj)).ConfigureAwait(false);
            await Task.Run(() => _context.Entry(obj).State = EntityState.Modified).ConfigureAwait(false);
        }

        public virtual async Task Delete(object id)
        {
            T existing = await _table.FindAsync(id).ConfigureAwait(false);
            _table.Remove(existing);
        }

        public virtual async Task Save()
        {
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
