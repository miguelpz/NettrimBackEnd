﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NettrimCh.Api.DataAccess.Contracts.Models;
using NettrimCh.Api.DataAccess.Contracts.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NettrimCh.Api.DataAccess.Repositories.GenericRepository
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
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

        public virtual async Task Add(IEnumerable<T> obj)
        {
            using (_context)
            using (var transaction = _context.Database.BeginTransactionAsync())
            {
                try
                {
                    await _table.AddRangeAsync(obj);
                    _context.SaveChanges();
                    await transaction.Result.CommitAsync();
                }
                catch (Exception ex)
                {
                    transaction.Result.Rollback();
                    throw new Exception(ex.Message);
                }
            }               
        }
             
        public virtual async Task<int> Update(int id, T entity)
        {
            var tipoTareaToUpdate = await _table.FindAsync(id).ConfigureAwait(false);

            if (tipoTareaToUpdate != null)
            {
                _context.Entry(tipoTareaToUpdate).State = EntityState.Detached;
                _table.Update(entity);                
                return await _context.SaveChangesAsync();
            }

            return 0;
           
        }

        public virtual async Task Update(IEnumerable<int> ids, IEnumerable<T> obj)
        {
            using (_context)
            using (var transaction = _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var registerMonthToUpdate = new List<T>();

                     ids.ToList().ForEach(o =>
                     {
                         registerMonthToUpdate.Add(_table.Find(o));

                     });

                    registerMonthToUpdate.ForEach(o =>
                    {
                        _context.Entry(o).State = EntityState.Detached;
                    });
                                      
                    _table.UpdateRange(obj);
                    _context.SaveChanges();
                    await transaction.Result.CommitAsync();
                }
                catch (Exception ex)
                {
                    transaction.Result.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }

        public virtual async Task<T> Delete(int id)
        {
            var objToDelete = await _table.FindAsync(id).ConfigureAwait(false);
            var result = _table.Remove(objToDelete);            
            await Save();
            return result.Entity;
        }

        public virtual async Task<T> Delete(T objToDelete)
        {           
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
