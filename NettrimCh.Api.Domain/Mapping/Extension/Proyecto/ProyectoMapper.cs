using AutoMapper;
using NettrimCh.Api.Domain.Mapping.Profile.Proyecto;
using System;
using System.Collections.Generic;
using System.Text;
using Models = NettrimCh.Api.DataAccess.Contracts.Models;

namespace NettrimCh.Api.Domain.Mapping.Extension.Proyecto
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

        public static IEnumerable<Entities.ProyectoEntity> toEntity(this IEnumerable<Models.Proyecto> model)
        {
            return model == null ? null : Mapper.Map<IEnumerable<Models.Proyecto>, IEnumerable<Entities.ProyectoEntity>>(model);
        }
        public static Entities.ProyectoEntity toEntity(this Models.Proyecto model)
        {
            return model == null ? null : Mapper.Map<Models.Proyecto, Entities.ProyectoEntity>(model);
        }

        public static Models.Proyecto toModel(this Entities.ProyectoEntity entity)
        {
            return entity == null ? null : Mapper.Map<Entities.ProyectoEntity, Models.Proyecto>(entity);
        }



    }
}
