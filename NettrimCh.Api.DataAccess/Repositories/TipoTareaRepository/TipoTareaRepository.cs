using NettrimCh.Api.DataAccess.Contracts.Models;
using NettrimCh.Api.DataAccess.Contracts.Repositories.ClienteRepository;
using NettrimCh.Api.DataAccess.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace NettrimCh.Api.DataAccess.Repositories.TipoTareaRepository
{
    public class TipoTareaRepository:GenericRepository<TipoTarea>, ITipoTareaRepository
    {
        public TipoTareaRepository(NettrimDbContext context)
        {
            _context = context;
            _table = _context.Set<TipoTarea>();
        }
    }
}
