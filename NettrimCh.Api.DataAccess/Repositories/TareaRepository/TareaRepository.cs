using NettrimCh.Api.DataAccess.Contracts.Models;
using NettrimCh.Api.DataAccess.Contracts.Repositories.TareaRepository;
using NettrimCh.Api.DataAccess.Models;
using NettrimCh.Api.DataAccess.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace NettrimCh.Api.DataAccess.Repositories.TareaRepository
{
   
        public class TareaRepository : GenericRepository<TareaModel>, ITareaRepository
        {
            public TareaRepository(NettrimChContext context)
            {
                _context = context;
                _table = _context.Set<TareaModel>();
            }
        }
    
}

