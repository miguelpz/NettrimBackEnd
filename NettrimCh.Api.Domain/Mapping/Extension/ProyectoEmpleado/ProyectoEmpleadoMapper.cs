using AutoMapper;
using NettrimCh.Api.Domain.Mapping.Profile.Cliente;
using System;
using System.Collections.Generic;
using System.Text;
using Models = NettrimCh.Api.DataAccess.Contracts.Models;
using Entities = NettrimCh.Api.Domain.Entities;
using NettrimCh.Api.Domain.Mapping.Profile.ProyectoEmpleado;

namespace NettrimCh.Api.Domain.Mapping.Extension.ProyectoEmpleado
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

        public static IEnumerable<Entities.ProyectoEmpleadoEntity> toEntity(this IEnumerable<Models.ProyectoEmpleado> model)
        {
            return model == null ? null : Mapper.Map<IEnumerable<Models.ProyectoEmpleado>, IEnumerable<Entities.ProyectoEmpleadoEntity>>(model);
        }
        public static Entities.ProyectoEmpleadoEntity toEntity(this Models.ProyectoEmpleado model)
        {
            return model == null ? null : Mapper.Map<Models.ProyectoEmpleado, Entities.ProyectoEmpleadoEntity>(model);
        }

        public static Models.ProyectoEmpleado toModel (this Entities.ProyectoEmpleadoEntity entity)
        {
            return entity == null ? null : Mapper.Map<Entities.ProyectoEmpleadoEntity, Models.ProyectoEmpleado>(entity);
        }



    }
}
