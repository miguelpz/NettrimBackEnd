using NettrimCh.Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NettrimCh.Api.Domain.ServicesContracts.TipoTarea
{
    public interface ITipoTareaDomainService
    {
        IEnumerable<TipoTareaEntity> GetAll();
        TipoTareaEntity GetByID(int id);
        TipoTareaEntity GetSingleOrDefault(string telefono);
        TipoTareaEntity Add(TipoTareaEntity clientEntity);
        void Update(int id, TipoTareaEntity clienteEntity);
        TipoTareaEntity Delete(int id);
    }
}
