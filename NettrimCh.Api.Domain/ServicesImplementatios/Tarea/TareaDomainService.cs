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
       

        public TareaDomainService(ITareaRepository TareaRepository)
        {
            _TareaRepository = TareaRepository;
           
        }

        public IEnumerable<TareaEntity> GetAll()
        {         
            var tareaList = _TareaRepository.GetAll().Result;
            return tareaList.toEntity();          
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
