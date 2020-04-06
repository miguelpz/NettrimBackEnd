using NettrimCh.Api.DataAccess.Contracts.Repositories.TareaAdjuntosRepository;
using NettrimCh.Api.Domain.Entities;
using NettrimCh.Api.Domain.Mapping.Extension.TareaAdjuntos;
using NettrimCh.Api.Domain.ServicesContracts.TareaAdjuntos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NettrimCh.Api.Domain.ServicesImplementatios.TareaAdjuntos
{
    public class TareaAdjuntosDomainService: ITareaAdjuntosDomainService
    {

        private readonly ITareaAdjuntosRepository _tareaAdjuntosrepository;


        public TareaAdjuntosDomainService(ITareaAdjuntosRepository tareaAdjuntosrepository)
        {
            _tareaAdjuntosrepository = tareaAdjuntosrepository;

        }

        public IEnumerable<TareaAdjuntosEntity> GetAll()
        {
            var adjuntosList = _tareaAdjuntosrepository.GetAll().Result;
            return adjuntosList.toEntity();
        }

        public TareaAdjuntosEntity GetByID(int id)
        {
            var adjunto = _tareaAdjuntosrepository.GetById(id).Result;
            return adjunto.toEntity();
        }

        public TareaAdjuntosEntity GetSingleOrDefault(string path)
        {
            var adjunto = _tareaAdjuntosrepository.GetSingleOrDefault(x => x.Path == path).Result;
            return adjunto.toEntity();
        }

        public TareaAdjuntosEntity Add(TareaAdjuntosEntity adjuntosEntity)
        {
            var adjuntoBypath = GetSingleOrDefault(adjuntosEntity.Path);

            if (adjuntoBypath != null)
            {
                throw new Exception("Element already exist");
            }

            var client = _tareaAdjuntosrepository.Add(adjuntosEntity.toModel()).Result;

            return client.toEntity();
        }
        public void Update(int id, TareaAdjuntosEntity adjuntoEntity)
        {
            if (adjuntoEntity.Id != id)
            {
                throw new Exception("Element id not equal to send object");
            }

            var result = _tareaAdjuntosrepository.Update(id, adjuntoEntity.toModel()).Result;

            if (result == 0)
            {
                throw new Exception("El elemento a actualizar no existe");
            }
        }

        public TareaAdjuntosEntity Delete(int id)
        {
            var adjuntoToDelete = _tareaAdjuntosrepository.GetById(id).Result;

            if (adjuntoToDelete == null)
            {
                throw new Exception("Element to delete no exist");
            }

            var deletedAdjunto = _tareaAdjuntosrepository.Delete(id).Result;
            return deletedAdjunto.toEntity();
        }
    }
        
}
