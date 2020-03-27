using NettrimCh.Api.DataAccess.Contracts.Models;
using NettrimCh.Api.DataAccess.Contracts.Repositories.CodigoOtRepository;
using NettrimCh.Api.DataAccess.Contracts.Repositories.Recursorepository;
using NettrimCh.Api.DataAccess.Models;
using NettrimCh.Api.DataAccess.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace NettrimCh.Api.DataAccess.Repositories.RecursoRepository
{
    public class RecursoRepository : GenericRepository<RecursoModel>, IRecursoRepository
    {
        public RecursoRepository(NettrimChContext context)
        {
            _context = context;
            _table = _context.Set<RecursoModel>();
        }
    }
}
