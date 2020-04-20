using AutoMapper;
using NettrimCh.Api.Application.Mapping.Profile.Cliente;
using NettrimCh.Api.Application.Mapping.Profile.ProyectoEmpleado;
using System;
using System.Collections.Generic;
using System.Text;
using Dtos = NettrimCh.Api.Application.Contracts.DTO;
using Entities = NettrimCh.Api.Domain.Entities;

namespace  NettrimCh.Api.Application.Mapping.Extension.Cliente
{
    public static class ProyectoEmpleadoMapper
    {
        internal static IMapper Mapper { get; }

        static ProyectoEmpleadoMapper()
        {
            Mapper = new MapperConfiguration
                    (cfg => { cfg.AddProfile<ProyectoEmpleadoProfile>(); })
                .CreateMapper();
        }

        public static IEnumerable<Dtos.ProyectoEmpleadoDto> toDto(this IEnumerable<Entities.ProyectoEmpleadoEntity> entity)
        {
            return entity == null ? null : Mapper.Map<IEnumerable<Entities.ProyectoEmpleadoEntity>,IEnumerable<Dtos.ProyectoEmpleadoDto>>(entity);          
        }

        public static Dtos.ProyectoEmpleadoDto toDto(this Entities.ProyectoEmpleadoEntity entity)
        {
            return entity == null ? null : Mapper.Map<Entities.ProyectoEmpleadoEntity, Dtos.ProyectoEmpleadoDto>(entity);
        }

        public static Entities.ProyectoEmpleadoEntity toEntity(this Dtos.ProyectoEmpleadoDto dto)
        {
            return dto == null ? null : Mapper.Map<Dtos.ProyectoEmpleadoDto, Entities.ProyectoEmpleadoEntity>(dto);
        }
    }
}
