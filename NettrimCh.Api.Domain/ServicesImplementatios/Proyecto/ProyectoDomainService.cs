using NettrimCh.Api.DataAccess.Contracts.Repositories.ClienteRepository;
using NettrimCh.Api.DataAccess.Contracts.Repositories.ProyectoRepository;
using NettrimCh.Api.Domain.Entities;
using NettrimCh.Api.Domain.Mapping.Extension.Cliente;
using NettrimCh.Api.Domain.ServicesContracts.Cliente;
using NettrimCh.Api.Domain.ServicesContracts.Proyecto;
using NettrimCh.Api.Domain.ServicesContracts.Tarea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;

namespace NettrimCh.Api.Domain.Services.Proyecto
{
    public class ProyectoDomainService: IProyectoDomainService
    {
        private readonly IProyectoRepository _proyectoRepository;
        private readonly IClienteRepository _clienteRepository;


        public ProyectoDomainService(
            IProyectoRepository proyectoRepository,
            IClienteRepository cilenteRepository
        )
        {
            _proyectoRepository = proyectoRepository;
            _clienteRepository = cilenteRepository;
           
        }

        public IEnumerable<ProyectoEntity> GetAll()
        {                
            var proyectoList =  from s in _proyectoRepository.GetAll().Result
                    join r in _clienteRepository.GetAll().Result on s.ClienteId equals r.Id
                    select (new ProyectoEntity()
                        {
                            Id= s.Id, 
                            ClienteId = s.ClienteId.Value,
                            Nombre = s.Nombre,
                            NombreCliente = r.Nombre,
                            Descripcion = s.Descripcion,
                            Interno = s.Interno,
                            Facturar = s.Facturar,
                            Area = s.Area,
                            Plataforma = s.Plataforma,
                            Cerrado = s.Cerrado,
                            FechaInicio = s.FechaInicio.Value,
                            FechaFin = s.FechaFin.Value
                        });

            return proyectoList.ToList();         
        }

        public ProyectoEntity GetByID (int id)
        {
            var client = _proyectoRepository.GetById(id).Result;
            return client.toEntity();
        }
       
        public ProyectoEntity Add (ProyectoEntity proyecto)
        {              
            var client = _proyectoRepository.Add(proyecto.toModel()).Result;
            return client.toEntity();
        }
        public void Update(int id, ProyectoEntity proyecto)
        {           
            if (proyecto.Id != id)
            {
                throw new Exception("Element id not equal to send object");
            }

            var result = _proyectoRepository.Update(id, proyecto.toModel()).Result;

            if (result == 0)
            {
                throw new Exception("El elemento a actualizar no existe");
            }
        }

        public ProyectoEntity Delete (int id)
        {
            var proyectoToDelete = _proyectoRepository.GetById(id).Result;

            if (proyectoToDelete == null)
            {
                throw new Exception("Element to delete no exist");
            }
            
            var deletedProyecto= _proyectoRepository.Delete(id).Result;
            return deletedProyecto.toEntity();
        }
      
    }
    
}
