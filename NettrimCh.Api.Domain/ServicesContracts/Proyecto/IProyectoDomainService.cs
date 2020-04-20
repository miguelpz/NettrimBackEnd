using NettrimCh.Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NettrimCh.Api.Domain.ServicesContracts.Proyecto
{
    public interface IProyectoDomainService
    {
        IEnumerable<ProyectoEntity> GetAll();
        ProyectoEntity GetByID(int id);
        ProyectoEntity Add(ProyectoEntity proyecto);
        ProyectoEmpleadoEntity AddEmpleado(int proyectoId, int empleadoId);
        public void Update(int id, ProyectoEntity proyecto);
        public ProyectoEntity Delete(int id);
        ProyectoEmpleadoEntity DeleteEmpleado(int proyectoId, int empleadoId);
        IEnumerable<EmpleadoEntity> GetEmpleados(int idProyecto);
        IEnumerable<EmpleadoEntity> GetEmpleadosToAdd(int idProyecto);
    }    
}
