using AutoMapper;
using NettrimCh.Api.Application.Mapping.Profile.Cliente;
using NettrimCh.Api.Application.Mapping.Profile.Empleado;
using System;
using System.Collections.Generic;
using System.Text;
using Dtos = NettrimCh.Api.Application.Contracts.DTO;
using Entities = NettrimCh.Api.Domain.Entities;

namespace  NettrimCh.Api.Application.Mapping.Extension.Empleado
{
    public static class EmpleadoMapper
    {
        internal static IMapper Mapper { get; }

        static EmpleadoMapper()
        {
            Mapper = new MapperConfiguration
                    (cfg => { cfg.AddProfile<EmpleadoProfile>(); })
                .CreateMapper();
        }

        public static IEnumerable<Dtos.EmpleadoDto> toDto(this IEnumerable<Entities.EmpleadoEntity> entity)
        {
            return entity == null ? null : Mapper.Map<IEnumerable<Entities.EmpleadoEntity>,IEnumerable<Dtos.EmpleadoDto>>(entity);          
        }

        public static Dtos.EmpleadoDto toDto(this Entities.EmpleadoEntity entity)
        {
            return entity == null ? null : Mapper.Map<Entities.EmpleadoEntity, Dtos.EmpleadoDto>(entity);
        }

        public static Entities.EmpleadoEntity toEntity(this Dtos.EmpleadoDto dto)
        {
            return dto == null ? null : Mapper.Map<Dtos.EmpleadoDto, Entities.EmpleadoEntity>(dto);
        }
    }
}
