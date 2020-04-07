using NettrimCh.Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NettrimCh.Api.Domain.ServicesContracts.Tarea
{
    public interface ITareaDomainService
    {
        IEnumerable<TareaEntity> GetAll();
        TareaEntity GetByID(int id);      
        TareaEntity Add(TareaEntity tareaEntity);
        void Update(int id, TareaEntity tareaEntity);
        TareaEntity Delete(int id);
    }
}
