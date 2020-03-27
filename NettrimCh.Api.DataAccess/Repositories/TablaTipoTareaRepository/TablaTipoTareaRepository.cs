using NettrimCh.Api.DataAccess.Contracts.Models;
using NettrimCh.Api.DataAccess.Contracts.Repositories.TablaTipoTareaRepository;
using NettrimCh.Api.DataAccess.Models;
using NettrimCh.Api.DataAccess.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace NettrimCh.Api.DataAccess.Repositories.TablaTipoTareaRepository
{
    public class TablaTipoTareaRepository : GenericRepository<TablaTipoTareaModel>, ITablaTipoTareaRepository
    {
        public TablaTipoTareaRepository(NettrimChContext context)
        {
            _context = context;
            _table = _context.Set<TablaTipoTareaModel>();
        }
    }
}
