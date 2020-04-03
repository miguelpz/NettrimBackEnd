using AutoMapper;
using NettrimCh.Api.DataAccess.Contracts.Repositories.GenericRepository;
using NettrimCh.Api.Domain.Mapping.Profile;
using NettrimCh.Api.Domain.ServicesContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NettrimCh.Api.Domain.ServicesImplementatios
{
    public class DomainServiceBase<M,E>: IDomainServiceBase<M, E>, ICustomFindable<M> where E:class where M:class 
    {
        private readonly IGenericRepository<M> _repository;
        private  IMapper Mapper { get; }


        public DomainServiceBase (IGenericRepository<M> repository)
        {
            _repository = repository;

            Mapper = new MapperConfiguration
                   (cfg => { cfg.AddProfile<GenericProfile<M,E>>(); }) 
               .CreateMapper();

        }                            
        public IEnumerable<E> GetAll()
        {
            var entityList = _repository.GetAll().Result;
            return ToEntity(entityList);  
        }

        public E GetByID(int id)
        {
            var client = _repository.GetById(id).Result;
            return ToEntity(client);  
        }

        public int GetSingleOrDefault()
        {
            throw new NotImplementedException();
        }

        public E Add(E entity)
        {
            int? id = GetSingleOrDefault();

            if (id == null)
            {
                throw new Exception("Element already exist");
            }

            var entityResult = _repository.Add(ToModel(entity)).Result;                       

            return ToEntity(entityResult);  
        }
        public void Update(int id, E entity)
        {
            if (clienteEntity.Id != id)
            {
                throw new Exception("Element id not equal to send object");
            }

            _clienteRepository.Update(id, clienteEntity.toModel());
        }

        public ClienteEntity Delete(int id)
        {
            var clienteToDelete = _clienteRepository.GetById(id).Result;

            if (clienteToDelete == null)
            {
                throw new Exception("Element to delete no exist");
            }

            var deletedCliente = _clienteRepository.Delete(id).Result;
            return deletedCliente.toEntity();
        }


        private  IEnumerable<E> ToEntity(IEnumerable<M> model)
        {
            return model == null ? null : Mapper.Map<IEnumerable<M>, IEnumerable<E>>(model);
        }
        private E ToEntity(M model)
        {
            return model == null ? null : Mapper.Map<M, E>(model);
        }

        private M ToModel(E entity)
        {
            return entity == null ? null : Mapper.Map<E, M>(entity);
        }

        
    }
}
