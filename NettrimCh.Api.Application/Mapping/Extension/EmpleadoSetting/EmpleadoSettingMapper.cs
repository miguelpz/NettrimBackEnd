using AutoMapper;
using NettrimCh.Api.Application.Mapping.Profile.Cliente;
using NettrimCh.Api.Application.Mapping.Profile.EmpleadoSetting;
using System;
using System.Collections.Generic;
using System.Text;
using Dtos = NettrimCh.Api.Application.Contracts.DTO;
using Entities = NettrimCh.Api.Domain.Entities;

namespace  NettrimCh.Api.Application.Mapping.Extension.Cliente
{
    public static class EmpleadoSettingMapper
    {
        internal static IMapper Mapper { get; }

        static EmpleadoSettingMapper()
        {
            Mapper = new MapperConfiguration
                    (cfg => { cfg.AddProfile<EmpleadoSettingProfile>(); })
                .CreateMapper();
        }

        public static IEnumerable<Dtos.EmpleadoSettingDto> toDto(this IEnumerable<Entities.EmpleadoSettingEntity> entity)
        {
            return entity == null ? null : Mapper.Map<IEnumerable<Entities.EmpleadoSettingEntity>,IEnumerable<Dtos.EmpleadoSettingDto>>(entity);          
        }

        public static Dtos.EmpleadoSettingDto toDto(this Entities.EmpleadoSettingEntity entity)
        {
            return entity == null ? null : Mapper.Map<Entities.EmpleadoSettingEntity, Dtos.EmpleadoSettingDto>(entity);
        }

        public static Entities.EmpleadoSettingEntity toEntity(this Dtos.EmpleadoSettingDto dto)
        {
            return dto == null ? null : Mapper.Map<Dtos.EmpleadoSettingDto, Entities.EmpleadoSettingEntity>(dto);
        }
    }
}
