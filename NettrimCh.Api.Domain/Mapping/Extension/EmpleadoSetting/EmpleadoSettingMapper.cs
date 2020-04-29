using AutoMapper;
using NettrimCh.Api.Domain.Mapping.Profile.Cliente;
using System;
using System.Collections.Generic;
using System.Text;
using Models = NettrimCh.Api.DataAccess.Contracts.Models;
using Entities = NettrimCh.Api.Domain.Entities;
using NettrimCh.Api.Domain.Mapping.Profile.Empleado;
using NettrimCh.Api.Domain.Mapping.Profile.EmpleadoSetting;

namespace NettrimCh.Api.Domain.Mapping.Extension.EmpleadoSetting
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

        public static IEnumerable<Entities.EmpleadoSettingEntity> toEntity(this IEnumerable<Models.EmpleadoSetting> model)
        {
            return model == null ? null : Mapper.Map<IEnumerable<Models.EmpleadoSetting>, IEnumerable<Entities.EmpleadoSettingEntity>>(model);
        }
        public static Entities.EmpleadoSettingEntity toEntity(this Models.EmpleadoSetting model)
        {
            return model == null ? null : Mapper.Map<Models.EmpleadoSetting, Entities.EmpleadoSettingEntity>(model);
        }

        public static Models.EmpleadoSetting toModel (this Entities.EmpleadoSettingEntity entity)
        {
            return entity == null ? null : Mapper.Map<Entities.EmpleadoSettingEntity, Models.EmpleadoSetting>(entity);
        }



    }
}
