using Microsoft.AspNetCore.Http;
using NettrimCh.Api.DataAccess.Contracts.Repositories.TareaAdjuntosRepository;
using NettrimCh.Api.DataAccess.Contracts.Repositories.TareaRepository;
using NettrimCh.Api.Domain.Entities;
using NettrimCh.Api.Domain.Mapping.Extension.TareaAdjuntos;
using NettrimCh.Api.Domain.ServicesContracts.Common;
using NettrimCh.Api.Domain.ServicesContracts.TareaAdjuntos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using NettrimCh.Api.DataAccess.Contracts.Repositories.ProyectoRepository;
using NettrimCh.Api.DataAccess.Contracts.Repositories.EmpleadoRepository;
using NettrimCh.Api.DataAccess.Contracts.Repositories.ClienteRepository;

namespace NettrimCh.Api.Domain.ServicesImplementatios.TareaAdjuntos
{
    public class TareaAdjuntosDomainService: ITareaAdjuntosDomainService
    {

        private readonly ITareaAdjuntosRepository _tareaAdjuntosrepository;
        private readonly ITipoTareaRepository _tipoTareaRepository;
        private readonly IEmpleadoRepository _empleadoRepository;
        private readonly ITareaRepository _tareaRepository;
        private readonly IAttachFileService _attachFileService;


        public TareaAdjuntosDomainService(ITareaAdjuntosRepository tareaAdjuntosrepository,
                                            ITareaRepository tareaRepository,
                                            IEmpleadoRepository empleadoRepository,
                                            IAttachFileService attachFileService,
                                            ITipoTareaRepository tipoTareaRepository)                                                   
        {
            _tareaAdjuntosrepository = tareaAdjuntosrepository;
            _tipoTareaRepository = tipoTareaRepository;
            _empleadoRepository = empleadoRepository;
            _tareaRepository = tareaRepository;
            _attachFileService = attachFileService;

        }

        public async Task AddAttachment ( int idTarea, IFormFile file)
        {
            var tarea = _tareaRepository.GetById(idTarea).Result;

            if (tarea.ProyectoId==null || tarea.EmpleadoId == null|| file==null)
            {
                throw new Exception("La tarea debe de tener un proyecto,un empleado asignados y un archivo a subir");
            }                       
           
            var firstSegment = tarea.ProyectoId.ToString();
            var secondSegment = tarea.Id + '\\' + _tipoTareaRepository.GetById(tarea.TipoTareaId).Result.Tipo;
            var thirdSegment = _empleadoRepository.GetById(tarea.EmpleadoId.Value).Result.Nombre;

            var filePath = System.IO.Path.Combine(firstSegment, secondSegment, thirdSegment);
            var filePathComplete = System.IO.Path.Combine(filePath, file.FileName);

            if (IsFileInDb(filePathComplete))
                throw new Exception("Ya exist ese fichero en la base de datos");
                
            var resultAddOperation = _attachFileService.AddFile(filePath, file).Result;
                       
            if (resultAddOperation.Ok)
            {
                try
                {
                    await _tareaAdjuntosrepository.Add(new TareaAdjuntosEntity(idTarea, resultAddOperation.Result).toModel());
                }catch (Exception ex){
                    throw new Exception(ex.Message);
                }                
            }
        }
        public bool IsFileInDb (string filePath)
        {                      
            return _tareaAdjuntosrepository.GetSingleOrDefault(x => x.Path == filePath).Result != null;                                     
        }

        public void DeleteAttachment(int idAttachment)
        {
            var attachmentToDelete = _tareaAdjuntosrepository.GetById(idAttachment).Result;
            

            if (attachmentToDelete == null)
            {
                throw new Exception("El archivo a eliminar no existe");
            }

            _tareaAdjuntosrepository.Delete(idAttachment);
                
            try
            {
                _attachFileService.DeleteFile(attachmentToDelete.Path);
            }
            catch (Exception ex)
            {
                _tareaAdjuntosrepository.Add(new TareaAdjuntosEntity(attachmentToDelete.TareaId, attachmentToDelete.Path).toModel());
                throw new Exception("No se pudo borrar el adjunto");
            }
                            
        }

    }
        
}
