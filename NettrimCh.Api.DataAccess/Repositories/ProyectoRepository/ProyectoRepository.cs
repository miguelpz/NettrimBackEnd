using NettrimCh.Api.DataAccess.Contracts.Models;
using NettrimCh.Api.DataAccess.Contracts.Repositories.ClienteRepository;
using NettrimCh.Api.DataAccess.Contracts.Repositories.ProyectoRepository;
using NettrimCh.Api.DataAccess.Contracts.Repositories.TareaRepository;
using NettrimCh.Api.DataAccess.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace NettrimCh.Api.DataAccess.Repositories.ProyectoRepository
{
    public class ProyectoRepository: GenericRepository<Proyecto>, IProyectoRepository
    {
        public ProyectoRepository(NettrimDbContext context)
        {
            _context = context;
            _table = _context.Set<Proyecto>();
        }
    }
}
