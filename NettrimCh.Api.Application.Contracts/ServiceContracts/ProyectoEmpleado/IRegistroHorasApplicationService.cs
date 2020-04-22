using NettrimCh.Api.Application.Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace NettrimCh.Api.Application.Contracts.ServiceContracts.ProyectoEmpleado
{
    public interface IRegistroHorasApplicationService
    {
        IEnumerable<RegistroHorasDto> GetMonthInputs(int tareaId, int month, int year);
        void UpdateMonthInputs(IEnumerable<int> ids, IEnumerable<RegistroHorasDto> registroHoras);
    }
}
