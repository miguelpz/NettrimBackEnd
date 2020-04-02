using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NettrimCh.Api.DataAccess.Contracts.Models;
using NettrimCh.Api.DataAccess.Contracts.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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

        public virtual async Task<T> GetById(int id)
        {
            return await _table.FindAsync(id).ConfigureAwait(false);
        }

        public virtual async Task<T> GetSingleOrDefault(Expression<Func<T, bool>> predicado)
        {
            return await _table.FirstOrDefaultAsync(predicado);
        }


        public virtual async Task<T> Add(T obj)
        {
            var result = await _table.AddAsync(obj);
            await Save();
            
            return result.Entity;                     
        }

        public virtual async Task Update(int id, T entity)
        {
            var clientToUpdate = _table.Find(id);

            if (clientToUpdate != null)
            {
                _context.Entry(clientToUpdate).State = EntityState.Detached;
                _table.Update(entity);
                await Save();                
            }
        }
        public virtual async Task<T> Delete(int id)
        {
            var objToDelete = await _table.FindAsync(id).ConfigureAwait(false);
            var result = _table.Remove(objToDelete);            
            await Save();
            return result.Entity;
        }

        public virtual async Task Save()
        {
            await _context.SaveChangesAsync().ConfigureAwait(false);

        }
    }
}
