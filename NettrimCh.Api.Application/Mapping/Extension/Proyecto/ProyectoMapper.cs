using AutoMapper;
using NettrimCh.Api.Application.Mapping.Profile.Cliente;
using NettrimCh.Api.Application.Mapping.Profile.Proyecto;
using System;
using System.Collections.Generic;
using System.Text;
using Dtos = NettrimCh.Api.Application.Contracts.DTO;
using Entities = NettrimCh.Api.Domain.Entities;


namespace NettrimCh.Api.Application.Mapping.Extension.Proyecto
{
    public static class ProyectoMapper
    {
        internal static IMapper Mapper { get; }

        static ProyectoMapper()
        {
            Mapper = new MapperConfiguration
                    (cfg => { cfg.AddProfile<ProyectoProfile>(); })
                .CreateMapper();
        }

        public static IEnumerable<Dtos.ProyectoDto> toDto(this IEnumerable<Entities.ProyectoEntity> entity)
        {
            return entity == null ? null : Mapper.Map<IEnumerable<Entities.ProyectoEntity>, IEnumerable<Dtos.ProyectoDto>>(entity);
        }

        public static Dtos.ProyectoDto toDto(this Entities.ProyectoEntity entity)
        {
            return entity == null ? null : Mapper.Map<Entities.ProyectoEntity, Dtos.ProyectoDto>(entity);
        }

        public static Entities.ProyectoEntity toEntity(this Dtos.ProyectoDto dto)
        {
            return dto == null ? null : Mapper.Map<Dtos.ProyectoDto, Entities.ProyectoEntity>(dto);
        }
    }
}
