using AutoMapper;
using NettrimCh.Api.Application.Mapping.Profile.Cliente;
using System;
using System.Collections.Generic;
using System.Text;
using Dtos = NettrimCh.Api.Application.Contracts.DTO;
using Entities = NettrimCh.Api.Domain.Entities;

namespace  NettrimCh.Api.Application.Mapping.Extension.Cliente
{
    public static class TipoTareaMapper
    {
        internal static IMapper Mapper { get; }

        static TipoTareaMapper()
        {
            Mapper = new MapperConfiguration
                    (cfg => { cfg.AddProfile<ClienteProfile>(); })
                .CreateMapper();
        }

        public static IEnumerable<Dtos.ClienteDto> toDto(this IEnumerable<Entities.ClienteEntity> entity)
        {
            return entity == null ? null : Mapper.Map<IEnumerable<Entities.ClienteEntity>,IEnumerable<Dtos.ClienteDto>>(entity);          
        }

        public static Dtos.ClienteDto toDto(this Entities.ClienteEntity entity)
        {
            return entity == null ? null : Mapper.Map<Entities.ClienteEntity, Dtos.ClienteDto>(entity);
        }

        public static Entities.ClienteEntity toEntity(this Dtos.ClienteDto dto)
        {
            return dto == null ? null : Mapper.Map<Dtos.ClienteDto, Entities.ClienteEntity>(dto);
        }
    }
}
