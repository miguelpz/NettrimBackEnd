using NettrimCh.Api.DataAccess.Contracts.Models;
using NettrimCh.Api.DataAccess.Contracts.Repositories.UsuarioOtsRepository;
using NettrimCh.Api.DataAccess.Models;
using NettrimCh.Api.DataAccess.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace NettrimCh.Api.DataAccess.Repositories.UsuarioOtsRepository
{

    public class UsuarioOtsRepository : GenericRepository<UsuarioOtsModel>, IUsuarioOtsRepository
    {
        public UsuarioOtsRepository(NettrimChContext context)
        {
            _context = context;
            _table = _context.Set<UsuarioOtsModel>();
        }
    }

}
