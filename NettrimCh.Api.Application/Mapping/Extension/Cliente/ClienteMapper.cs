using AutoMapper;
using NettrimCh.Api.Application.Mapping.Profile.Cliente;
using System;
using System.Collections.Generic;
using System.Text;
using Dtos = NettrimCh.Api.Application.Contracts.DTO;
using Entities = NettrimCh.Api.Domain.Entities;

namespace  NettrimCh.Api.Application.Mapping.Extension.Cliente
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

        public static IEnumerable<Dtos.ClienteDto> toEntity(this IEnumerable<Entities.ClienteEntity> entity)
        {
            return entity == null ? null : Mapper.Map<IEnumerable<Entities.ClienteEntity>,IEnumerable<Dtos.ClienteDto>>(entity);          
        }
    }
}
