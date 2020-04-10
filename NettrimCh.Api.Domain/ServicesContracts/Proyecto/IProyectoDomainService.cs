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
        ProyectoEntity GetSingleOrDefault(string nombre);
        ProyectoEntity Add(ProyectoEntity proyEntity);
        void Update(int id, ProyectoEntity proyectoEntity);
        ProyectoEntity Delete(int id);


    }
}
