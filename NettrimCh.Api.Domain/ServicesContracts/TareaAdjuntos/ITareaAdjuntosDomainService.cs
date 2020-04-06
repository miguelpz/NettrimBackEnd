using NettrimCh.Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NettrimCh.Api.Domain.ServicesContracts.TareaAdjuntos
{
    public interface ITareaAdjuntosDomainService
    {
        IEnumerable<TareaAdjuntosEntity> GetAll();
        TareaAdjuntosEntity GetByID(int id);
        TareaAdjuntosEntity GetSingleOrDefault(string path);
        TareaAdjuntosEntity Add(TareaAdjuntosEntity adjuntosEntity);
        void Update(int id, TareaAdjuntosEntity adjuntoEntity);
        TareaAdjuntosEntity Delete(int id);
    }
}

