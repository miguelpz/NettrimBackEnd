using AutoMapper;
using NettrimCh.Api.Application.Mapping.Profile.TipoTarea;
using System.Collections.Generic;
using Dtos = NettrimCh.Api.Application.Contracts.DTO;
using Entities = NettrimCh.Api.Domain.Entities;

namespace NettrimCh.Api.Application.Mapping.Extension.TipoTarea
{
    public static class TipoTareaMapper
    {
        internal static IMapper Mapper { get; }

        static TipoTareaMapper()
        {
            Mapper = new MapperConfiguration
                    (cfg => { cfg.AddProfile<TipoTareaProfile>(); })
                .CreateMapper();
        }

        public static IEnumerable<Dtos.TipoTareaDto> toDto(this IEnumerable<Entities.TipoTareaEntity> entity)
        {
            return entity == null ? null : Mapper.Map<IEnumerable<Entities.TipoTareaEntity>,IEnumerable<Dtos.TipoTareaDto>>(entity);          
        }

        public static Dtos.TipoTareaDto toDto(this Entities.TipoTareaEntity entity)
        {
            return entity == null ? null : Mapper.Map<Entities.TipoTareaEntity, Dtos.TipoTareaDto>(entity);
        }

        public static Entities.TipoTareaEntity toEntity(this Dtos.TipoTareaDto dto)
        {
            return dto == null ? null : Mapper.Map<Dtos.TipoTareaDto, Entities.TipoTareaEntity>(dto);
        }
    }
}
