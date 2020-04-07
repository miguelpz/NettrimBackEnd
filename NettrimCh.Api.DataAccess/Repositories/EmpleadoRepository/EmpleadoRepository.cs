using NettrimCh.Api.DataAccess.Contracts.Models;
using NettrimCh.Api.DataAccess.Contracts.Repositories.EmpleadoRepository;
using NettrimCh.Api.DataAccess.Repositories.GenericRepository;

namespace NettrimCh.Api.DataAccess.Repositories.EmpleadoRepository
{
    public class EmpleadoRepository:GenericRepository<Empleado>,IEmpleadoRepository
    {
        public EmpleadoRepository(NettrimDbContext context)
        {
            _context = context;
            _table = _context.Set<Empleado>();
        }
    }
}
