using NettrimCh.Api.DataAccess.Contracts.Repositories.ClienteRepository;
using NettrimCh.Api.Domain.Mapping.Extension.TipoTarea;
using NettrimCh.Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using NettrimCh.Api.Domain.ServicesContracts.TipoTarea;

namespace NettrimCh.Api.Domain.ServicesImplementatios.TipoTarea
{
    public class TipoTareaDomainService: ITipoTareaDomainService
    {
        private readonly ITipoTareaRepository _tipoTareaRepository;


        public TipoTareaDomainService(ITipoTareaRepository tipoTareaRepository)
        {
            _tipoTareaRepository = tipoTareaRepository;

        }

        public IEnumerable<TipoTareaEntity> GetAll()
        {
            var clientList = _tipoTareaRepository.GetAll().Result;
            return clientList.toEntity();
        }

        public TipoTareaEntity GetByID(int id)
        {
            var client = _tipoTareaRepository.GetById(id).Result;
            return client.toEntity();
        }

        public TipoTareaEntity GetSingleOrDefault(string tipo)
        {
            var cliente = _tipoTareaRepository.GetSingleOrDefault(x => x.Tipo == tipo).Result;
            return cliente.toEntity();
        }

        public TipoTareaEntity Add(TipoTareaEntity tipoTareaEntity)
        {
            var clientByTelefono = GetSingleOrDefault(tipoTareaEntity.Tipo);

            if (clientByTelefono != null)
            {
                throw new Exception("Element already exist");
            }

            var tipoTareaAdded = _tipoTareaRepository.Add(tipoTareaEntity.toModel()).Result;

            return tipoTareaAdded.toEntity();
        }
        public void Update(int id, TipoTareaEntity tipoTareaEntity)
        {            
            if (tipoTareaEntity.Id != id)
            {
                throw new Exception("Element id not equal to send object");
            }
           
            var result = _tipoTareaRepository.Update(id, tipoTareaEntity.toModel()).Result;

            if (result == 0)
            {
                throw new Exception("Element to Update no exist");
            }
        }

        public TipoTareaEntity Delete(int id)
        {
            var clienteToDelete = _tipoTareaRepository.GetById(id).Result;

            if (clienteToDelete == null)
            {
                throw new Exception("Element to delete no exist");
            }

            var deletedCliente = _tipoTareaRepository.Delete(id).Result;
            return deletedCliente.toEntity();
        }
    }
}
