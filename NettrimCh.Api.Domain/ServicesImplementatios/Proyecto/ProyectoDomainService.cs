using NettrimCh.Api.DataAccess.Contracts.Repositories.ProyectoRepository;
using NettrimCh.Api.Domain.Entities;
using NettrimCh.Api.Domain.Mapping.Extension.Proyecto;
using NettrimCh.Api.Domain.ServicesContracts.Proyecto;
using System;
using System.Collections.Generic;
using System.Text;

namespace NettrimCh.Api.Domain.ServicesImplementatios.Proyecto
{
    public class ProyectoDomainService : IProyectoDomainService
    {
        private readonly IProyectoRepository _proyectoRepository;

        public ProyectoDomainService(IProyectoRepository proyectoRepository)
        {
            _proyectoRepository = proyectoRepository;

        }

        public IEnumerable<ProyectoEntity> GetAll()
        {
            var proyectList = _proyectoRepository.GetAll().Result;
            return proyectList.toEntity();
        }
        public ProyectoEntity GetByID(int id)
        {
            var proyect = _proyectoRepository.GetById(id).Result;
            return proyect.toEntity();
        }
        public ProyectoEntity GetSingleOrDefault(string nombre)
        {
            var proyecto = _proyectoRepository.GetSingleOrDefault(x => x.Nombre == nombre).Result;
            return proyecto.toEntity();
        }
        public ProyectoEntity Add(ProyectoEntity proyEntity)
        {
            var proyectoByNombre = GetSingleOrDefault(proyEntity.Nombre);

            if (proyectoByNombre != null)
            {
                throw new Exception("Element already exist");
            }

            var proy = _proyectoRepository.Add(proyEntity.toModel()).Result;

            return proy.toEntity();
        }
        public void Update(int id, ProyectoEntity proyectoEntity)
        {
            if (proyectoEntity.Id != id)
            {
                throw new Exception("Element id not equal to send object");
            }

            var result = _proyectoRepository.Update(id, proyectoEntity.toModel()).Result;

            if (result == 0)
            {
                throw new Exception("El elemento a actualizar no existe");
            }
        }

        public ProyectoEntity Delete(int id)
        {
            var proyectoToDelete = _proyectoRepository.GetById(id).Result;

            if (proyectoToDelete == null)
            {
                throw new Exception("Element to delete no exist");
            }

            var deletedProyecto = _proyectoRepository.Delete(id).Result;
            return deletedProyecto.toEntity();
        }

     
    }
}
