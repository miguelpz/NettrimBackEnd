using NettrimCh.Api.DataAccess.Contracts.Repositories.ClienteRepository;
using NettrimCh.Api.DataAccess.Contracts.Repositories.EmpleadoRepository;
using NettrimCh.Api.DataAccess.Contracts.Repositories.ProyectoRepository;
using NettrimCh.Api.DataAccess.Contracts.Repositories.TareaRepository;
using NettrimCh.Api.Domain.Entities;
using NettrimCh.Api.Domain.Mapping.Extension.Tarea;
using NettrimCh.Api.Domain.ServicesContracts.Tarea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace NettrimCh.Api.Domain.Services.Tarea
{
    public class TareaDomainService:ITareaDomainService
    {
        private readonly ITareaRepository _TareaRepository;
        private readonly IEmpleadoRepository _empleadoRepository;
        private readonly IProyectoRepository _proyectoRepository;
        private readonly ITipoTareaRepository _tipoTareaRepository;



        public TareaDomainService(  ITareaRepository TareaRepository,
                                    IEmpleadoRepository empleadoRepository,
                                    IProyectoRepository proyectoRepository,
                                    ITipoTareaRepository tipoTareaRepository)       
        {
            _TareaRepository = TareaRepository;
            _empleadoRepository = empleadoRepository;
            _proyectoRepository = proyectoRepository;
            _tipoTareaRepository = tipoTareaRepository;
        }

        public IEnumerable<TareaEntity> GetAll()
        {
            //var tareaList = from tareas in _TareaRepository.GetAll().Result
            //                join  empleados in _empleadoRepository.GetAll().Result on tareas.EmpleadoId equals empleados.Id
            //                join proyectos in _proyectoRepository.GetAll().Result on tareas.ProyectoId equals proyectos.Id
            //                join tipotareas in _tipoTareaRepository.GetAll().Result on tareas.TipoTareaId equals tipotareas.Id
            //                select (new TareaEntity()
            //                {
            //                    Id = tareas.Id,
            //                    FechaInicio = tareas.FechaInicio,
            //                    TipoTareaNombre = tipotareas.Tipo,
            //                    Descripcion = tareas.Descripcion,
            //                    EmpleadoNombre = empleados.Nombre + ' ' + empleados.Apellido1 + ' ' + empleados.Apellido2,
            //                    NombreProyecto = proyectos.Nombre,
            //                    ProyectoId = tareas.ProyectoId,
            //                    TipoTareaId= tareas.TipoTareaId,
            //                    EmpleadoId= tareas.EmpleadoId                                
            //                });

            var tareaList = from tareas in _TareaRepository.GetAll().Result
                            from empleados in _empleadoRepository.GetAll().Result.Where(empleados => empleados.Id==tareas.EmpleadoId).DefaultIfEmpty()
                            from proyectos in _proyectoRepository.GetAll().Result.Where(proyectos => proyectos.Id==tareas.ProyectoId).DefaultIfEmpty()
                            from tipotareas in _tipoTareaRepository.GetAll().Result.Where(tipotareas => tipotareas.Id==tareas.TipoTareaId).DefaultIfEmpty()
                            select (new TareaEntity()
                            {
                                Id = tareas.Id,
                                FechaInicio = tareas.FechaInicio,
                                TipoTareaNombre = tipotareas.Tipo,
                                Descripcion = tareas.Descripcion,
                                EmpleadoNombre = empleados?.Nombre ?? " " +  empleados?.Apellido1 ?? " " + empleados?.Apellido2 ?? " ",
                                NombreProyecto = proyectos.Nombre,
                                ProyectoId = tareas.ProyectoId,
                                TipoTareaId = tareas.TipoTareaId,
                                EmpleadoId = tareas.EmpleadoId
                            });


            //join empleados in _empleadoRepository.GetAll().Result on tareas.EmpleadoId equals empleados.Id into tar_emp_group
            //                from tar_emp in tar_emp_group.DefaultIfEmpty()
            //                join proyectos in _proyectoRepository.GetAll().Result on tar_emp.Tarea.R     .ProyectoId equals proyectos.Id into tar_pro_group


            //                //join proyectos in _proyectoRepository.GetAll().Result on tareas.ProyectoId equals proyectos.Id into tar_pro_group
            //                //join tipotareas in _tipoTareaRepository.GetAll().Result on tareas.TipoTareaId equals tipotareas.Id into tar_tipotarea_group

            //                //from tar_emp in tar_emp_group.DefaultIfEmpty()
            //                //from tar_pro in tar_pro_group.DefaultIfEmpty()
            //                //from tar_t
            //                //select new { tareas, tar_emp.de };

            return tareaList.ToList();       
        }

        public TareaEntity GetByID (int id)
        {
            var tarea = _TareaRepository.GetById(id).Result;
            return tarea.toEntity();
        }
        

        public TareaEntity Add (TareaEntity tareaEntity)
        {
            var clientByTelefono = GetByID(tareaEntity.Id);

            if (clientByTelefono != null)
            {
                throw new Exception("Element already exist");
            }
           
            var client = _TareaRepository.Add(tareaEntity.toModel()).Result;

            return client.toEntity();
        }
        public void Update(int id, TareaEntity tareaEntity)
        {
            if (tareaEntity.Id != id)
            {
                throw new Exception("Element id not equal to send object");
            }

            var result = _TareaRepository.Update(id, tareaEntity.toModel()).Result;

            if (result == 0)
            {
                throw new Exception("El elemento a actualizar no existe");
            }
        }

        public TareaEntity Delete (int id)
        {
            var tareaToDelete = _TareaRepository.GetById(id).Result;

            if (tareaToDelete == null)
            {
                throw new Exception("Element to delete no exist");
            }
            
            var deletedTarea= _TareaRepository.Delete(id).Result;
            return deletedTarea.toEntity();
        }
    }
    
}
