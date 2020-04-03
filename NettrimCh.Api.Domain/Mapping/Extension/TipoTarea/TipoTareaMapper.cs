using AutoMapper;
using NettrimCh.Api.Domain.Mapping.Profile.Cliente;
using System;
using System.Collections.Generic;
using System.Text;
using Models = NettrimCh.Api.DataAccess.Contracts.Models;
using Entities = NettrimCh.Api.Domain.Entities;
using NettrimCh.Api.Domain.Mapping.Profile.TipoTarea;

namespace NettrimCh.Api.Domain.Mapping.Extension.TipoTarea
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

        public static IEnumerable<Entities.TipoTareaEntity> toEntity(this IEnumerable<Models.TipoTarea> model)
        {
            return model == null ? null : Mapper.Map<IEnumerable<Models.TipoTarea>, IEnumerable<Entities.TipoTareaEntity>>(model);
        }
        public static Entities.TipoTareaEntity toEntity(this Models.TipoTarea model)
        {
            return model == null ? null : Mapper.Map<Models.TipoTarea, Entities.TipoTareaEntity>(model);
        }

        public static Models.TipoTarea toModel (this Entities.TipoTareaEntity entity)
        {
            return entity == null ? null : Mapper.Map<Entities.TipoTareaEntity, Models.TipoTarea>(entity);
        }



    }
}
