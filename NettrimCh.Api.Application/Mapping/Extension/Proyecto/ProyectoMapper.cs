using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

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
            return entity == null ? null : Mapper.Map<IEnumerable<Entities.ClienteEntity>, IEnumerable<Dtos.ClienteDto>>(entity);
        }
    }
}
