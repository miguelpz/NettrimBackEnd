using AutoMapper;
using NettrimCh.Api.Application.Mapping.Profile.Cliente;
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

        public static IEnumerable<Dtos.ProyectoDto> toEntity(this IEnumerable<Domain.Entities.ProyectoEntity> entity)
        {
            return entity == null ? null : Mapper.Map<IEnumerable<Entities.ProyectoEntity>, IEnumerable<Dtos.ProyectoDto>>(entity);
        }
    }
}
