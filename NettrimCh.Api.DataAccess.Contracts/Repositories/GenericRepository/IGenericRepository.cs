using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NettrimCh.Api.DataAccess.Contracts.Repositories.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(object id);
        Task Add(T entity);
        Task<bool> Update(int id, T obj);
        Task Delete(object id);
        Task Save();
    }
}
