using AutoMapper;
using NettrimCh.Api.Domain.Mapping.Profile.Cliente;
using System;
using System.Collections.Generic;
using System.Text;
using Models = NettrimCh.Api.DataAccess.Contracts.Models;
using Entities = NettrimCh.Api.Domain.Entities;

namespace NettrimCh.Api.Domain.Mapping.Extension.Cliente
{
    public static class ClienteMapper
    {
        internal static IMapper Mapper { get; }

        static ClienteMapper()
        {
            Mapper = new MapperConfiguration
                    (cfg => { cfg.AddProfile<ClienteProfile>(); })
                .CreateMapper();
        }

        public static IEnumerable<Entities.ClienteEntity> toEntity(this IEnumerable<Models.Cliente> model)
        {
            return model == null ? null : Mapper.Map<IEnumerable<Models.Cliente>, IEnumerable<Entities.ClienteEntity>>(model);
        }

        public static Models.Cliente toModel (this Entities.ClienteEntity entity)
        {
            return entity == null ? null : Mapper.Map<Entities.ClienteEntity, Models.Cliente>(entity);
        }



    }
}
