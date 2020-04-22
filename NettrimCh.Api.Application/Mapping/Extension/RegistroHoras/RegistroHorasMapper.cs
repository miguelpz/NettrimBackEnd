using AutoMapper;
using NettrimCh.Api.Application.Mapping.Profile.Cliente;
using System;
using System.Collections.Generic;
using System.Text;
using Dtos = NettrimCh.Api.Application.Contracts.DTO;
using Entities = NettrimCh.Api.Domain.Entities;

namespace  NettrimCh.Api.Application.Mapping.Extension.RegistroHoras
{
    public static class RegistroHorasMapper
    {
        internal static IMapper Mapper { get; }

        static RegistroHorasMapper()
        {
            Mapper = new MapperConfiguration
                    (cfg => { cfg.AddProfile<RegistroHorasProfile>(); })
                .CreateMapper();
        }

        public static IEnumerable<Dtos.RegistroHorasDto> toDto(this IEnumerable<Entities.RegistroHorasEntity> entity)
        {
            return entity == null ? null : Mapper.Map<IEnumerable<Entities.RegistroHorasEntity>,IEnumerable<Dtos.RegistroHorasDto>>(entity);          
        }

        public static Dtos.RegistroHorasDto toDto(this Entities.RegistroHorasEntity entity)
        {
            return entity == null ? null : Mapper.Map<Entities.RegistroHorasEntity, Dtos.RegistroHorasDto>(entity);
        }

        public static IEnumerable<Entities.RegistroHorasEntity> toEntity(this IEnumerable<Dtos.RegistroHorasDto> dto)
        {
            return dto == null ? null : Mapper.Map<IEnumerable<Dtos.RegistroHorasDto>, IEnumerable<Entities.RegistroHorasEntity>>(dto);
        }

        public static Entities.RegistroHorasEntity toEntity(this Dtos.RegistroHorasDto dto)
        {
            return dto == null ? null : Mapper.Map<Dtos.RegistroHorasDto, Entities.RegistroHorasEntity>(dto);
        }
    }
}
