using AutoMapper;
using NettrimCh.Api.Application.Mapping.Profile.Cliente;
using System;
using System.Collections.Generic;
using System.Text;
using Dtos = NettrimCh.Api.Application.Contracts.DTO;
using Entities = NettrimCh.Api.Domain.Entities;

namespace  NettrimCh.Api.Application.Mapping.Extension.Cliente
{
    public static class TareaMapper
    {
        internal static IMapper Mapper { get; }

        static TareaMapper()
        {
            Mapper = new MapperConfiguration
                    (cfg => { cfg.AddProfile<TareaProfile>(); })
                .CreateMapper();
        }

        public static IEnumerable<Dtos.TareaDto> toDto(this IEnumerable<Entities.TareaEntity> entity)
        {
            return entity == null ? null : Mapper.Map<IEnumerable<Entities.TareaEntity>,IEnumerable<Dtos.TareaDto>>(entity);          
        }

        public static Dtos.TareaDto toDto(this Entities.TareaEntity entity)
        {
            return entity == null ? null : Mapper.Map<Entities.TareaEntity, Dtos.TareaDto>(entity);
        }

        public static Entities.TareaEntity toEntity(this Dtos.TareaDto dto)
        {
            return dto == null ? null : Mapper.Map<Dtos.TareaDto, Entities.TareaEntity>(dto);
        }
    }
}
