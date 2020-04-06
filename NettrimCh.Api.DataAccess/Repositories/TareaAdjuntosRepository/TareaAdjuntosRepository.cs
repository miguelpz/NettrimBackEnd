using NettrimCh.Api.DataAccess.Contracts.Models;
using NettrimCh.Api.DataAccess.Contracts.Repositories.TareaAdjuntosRepository;
using NettrimCh.Api.DataAccess.Repositories.GenericRepository;

namespace NettrimCh.Api.DataAccess.Repositories.TareaAdjuntosRepository
{
    public class TareaAdjuntosRepository:GenericRepository<TareaAdjuntos>,ITareaAdjuntosRepository
    {
        public TareaAdjuntosRepository(NettrimDbContext context)
        {
            _context = context;
            _table = _context.Set<TareaAdjuntos>();
        }
    }
}
