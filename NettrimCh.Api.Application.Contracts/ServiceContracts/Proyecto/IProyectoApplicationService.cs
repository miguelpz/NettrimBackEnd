using NettrimCh.Api.Application.Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace NettrimCh.Api.Application.Contracts.ServiceContracts.Proyecto
{
    public interface IProyectoApplicationService
    {
        IEnumerable<ProyectoDto> GetAll();
        ProyectoDto GetById(int id);
        ProyectoDto Add(ProyectoDto proyecto);
        ProyectoEmpleadoDto AddEmpleado(int proyectoId, int empleadoId);
        void Update(int id, ProyectoDto proyecto);
        ProyectoDto Delete(int id);
        ProyectoEmpleadoDto DeleteEmpleado(int proyectoId, int empleadoId);
        IEnumerable<EmpleadoDto> GetEmpleados(int idProyecto);
        IEnumerable<EmpleadoDto> GetEmpleadosToAdd(int idProyecto);
    }
}