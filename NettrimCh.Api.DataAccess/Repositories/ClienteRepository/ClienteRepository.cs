using NettrimCh.Api.DataAccess.Contracts.Models;
using NettrimCh.Api.DataAccess.Contracts.Repositories.ClienteRepository;
using NettrimCh.Api.DataAccess.Models;
using NettrimCh.Api.DataAccess.Repositories.GenericRepository;

namespace NettrimCh.Api.DataAccess.Repositories.ClienteRepository
{
    public class ClienteRepository:GenericRepository<ClienteModel>, IClienteRepository
    {
        public ClienteRepository(NettrimChContext context)
        {
            _context = context;
            _table = _context.Set<ClienteModel>();
        }
    }
}
