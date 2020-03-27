using NettrimCh.Api.DataAccess.Contracts.Models;
using NettrimCh.Api.DataAccess.Contracts.Repositories.CodigoOtRepository;
using NettrimCh.Api.DataAccess.Models;
using NettrimCh.Api.DataAccess.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace NettrimCh.Api.DataAccess.Repositories.CodigoOtRepository
{
    public class CodigoOtRepository : GenericRepository<CodigoOtModel>, ICodigoOtRepository
    {
        public CodigoOtRepository(NettrimChContext context)
        {
            _context = context;
            _table = _context.Set<CodigoOtModel>();
        }
    }
}
