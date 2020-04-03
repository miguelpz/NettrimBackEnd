using NettrimCh.Api.Application.Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace NettrimCh.Api.Application.Contracts.ServiceContracts.TipoTarea
{
    public interface ITipoTareaApplicationService
    {
        IEnumerable<TipoTareaDto> GetAll();
        TipoTareaDto GetById(int id);
        TipoTareaDto Add(TipoTareaDto cliente);
        void Update(int id, TipoTareaDto cliente);
        TipoTareaDto Delete(int id);
    }
}
