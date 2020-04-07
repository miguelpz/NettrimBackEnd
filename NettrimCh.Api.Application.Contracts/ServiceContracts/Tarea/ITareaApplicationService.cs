using NettrimCh.Api.Application.Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace NettrimCh.Api.Application.Contracts.ServiceContracts.Tarea
{
    public interface ITareaApplicationService
    {
        IEnumerable<TareaDto> GetAll();
        TareaDto GetById(int id);
        TareaDto Add(TareaDto tarea);
        void Update(int id, TareaDto tarea);
        TareaDto Delete(int id);
    }
}
