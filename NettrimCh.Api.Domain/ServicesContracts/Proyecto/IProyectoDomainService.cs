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
        public void Update(int id, ProyectoEntity proyecto);
        public ProyectoEntity Delete(int id);
    }    
}
