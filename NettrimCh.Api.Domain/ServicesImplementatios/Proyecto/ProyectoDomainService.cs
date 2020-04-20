using NettrimCh.Api.DataAccess.Contracts.Models;
using NettrimCh.Api.DataAccess.Contracts.Repositories.ClienteRepository;
using NettrimCh.Api.DataAccess.Contracts.Repositories.EmpleadoRepository;
using NettrimCh.Api.DataAccess.Contracts.Repositories.ProyectoEmpleadoRepository;
using NettrimCh.Api.DataAccess.Contracts.Repositories.ProyectoRepository;
using NettrimCh.Api.Domain.Entities;
using NettrimCh.Api.Domain.Mapping.Extension.Cliente;
using NettrimCh.Api.Domain.Mapping.Extension.Empleado;
using NettrimCh.Api.Domain.Mapping.Extension.ProyectoEmpleado;
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
        private readonly IProyectoEmpleadoRepository _proyectoEmpleadoRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IEmpleadoRepository _empleadoRepository;



        public ProyectoDomainService(
            IProyectoRepository proyectoRepository,
            IClienteRepository cilenteRepository,
            IProyectoEmpleadoRepository proyectoEmpleadoRepository,
            IEmpleadoRepository empleadoRepository
        )
        {
            _proyectoRepository = proyectoRepository;
            _clienteRepository = cilenteRepository;
            _proyectoEmpleadoRepository = proyectoEmpleadoRepository;
            _empleadoRepository = empleadoRepository;
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

        public IEnumerable<EmpleadoEntity> GetEmpleados (int idProyecto)
        {
            var empleadoList=   from p in _proyectoRepository.GetAll().Result
                                join pe in _proyectoEmpleadoRepository.GetAll().Result on p.Id equals pe.ProyectoId
                                join e in _empleadoRepository.GetAll().Result on pe.EmpleadoId equals e.Id
                                where pe.ProyectoId == idProyecto
                                select e;

            return empleadoList.ToList().toEntity();
        }

        public IEnumerable<EmpleadoEntity> GetEmpleadosToAdd(int idProyecto)
        {
            var empleadoList = from p in _proyectoRepository.GetAll().Result
                               join pe in _proyectoEmpleadoRepository.GetAll().Result on p.Id equals pe.ProyectoId
                               join e in _empleadoRepository.GetAll().Result on pe.EmpleadoId equals e.Id
                               where pe.ProyectoId == idProyecto
                               select e;

            var empleadosToAdd = _empleadoRepository.GetAll().Result.Where(emp => !empleadoList.Contains(emp));

            return empleadosToAdd.ToList().toEntity();
        }

        public ProyectoEmpleadoEntity AddEmpleado (int proyectoId, int empleadoId)
        {
            if (proyectoId == 0 || empleadoId == 0)
            {
                throw new Exception("Debe de haber un proyecto y un empleado para añadir");
            }

            var proyectoEmpleadoAdded = _proyectoEmpleadoRepository.Add(new ProyectoEmpleadoEntity()
            {
                ProyectoId = proyectoId,
                EmpleadoId = empleadoId
            }.toModel()).Result.toEntity();

            return proyectoEmpleadoAdded;
        }

        public ProyectoEmpleadoEntity DeleteEmpleado(int proyectoId, int empleadoId)
        {
            var toDelete = _proyectoEmpleadoRepository.GetSingleOrDefault(p => 
                                                            p.ProyectoId == proyectoId && 
                                                            p.EmpleadoId == empleadoId).Result;
            if (toDelete == null)
                throw new Exception("Elemento a borrar no existe");

            return _proyectoEmpleadoRepository.Delete(toDelete).Result.toEntity();                                
        }

    }
    
}
