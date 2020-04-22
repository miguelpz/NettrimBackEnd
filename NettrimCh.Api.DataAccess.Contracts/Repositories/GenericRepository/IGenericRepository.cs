using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NettrimCh.Api.DataAccess.Contracts.Repositories.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> GetSingleOrDefault(Expression<Func<T, bool>> predicado);
        Task<T> Add(T entity);
        Task Add(IEnumerable<T> obj);      
        Task<int> Update(int id, T entity);
        Task Update(IEnumerable<int> ids, IEnumerable<T> obj);
        Task<T> Delete(int id);
        Task<T> Delete(T objToDelete);
        Task Save();
    }
}
