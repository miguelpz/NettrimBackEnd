using AutoMapper;
using NettrimCh.Api.Domain.Mapping.Profile.Cliente;
using System;
using System.Collections.Generic;
using System.Text;
using Models = NettrimCh.Api.DataAccess.Contracts.Models;
using Entities = NettrimCh.Api.Domain.Entities;
using NettrimCh.Api.Domain.Mapping.Profile.Empleado;

namespace NettrimCh.Api.Domain.Mapping.Extension.Empleado
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

        public static IEnumerable<Entities.EmpleadoEntity> toEntity(this IEnumerable<Models.Empleado> model)
        {
            return model == null ? null : Mapper.Map<IEnumerable<Models.Empleado>, IEnumerable<Entities.EmpleadoEntity>>(model);
        }
        public static Entities.EmpleadoEntity toEntity(this Models.Empleado model)
        {
            return model == null ? null : Mapper.Map<Models.Empleado, Entities.EmpleadoEntity>(model);
        }

        public static Models.Empleado toModel (this Entities.EmpleadoEntity entity)
        {
            return entity == null ? null : Mapper.Map<Entities.EmpleadoEntity, Models.Empleado>(entity);
        }



    }
}
