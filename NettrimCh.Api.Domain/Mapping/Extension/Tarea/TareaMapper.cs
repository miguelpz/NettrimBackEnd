using AutoMapper;
using NettrimCh.Api.Domain.Mapping.Profile.Tarea;
using System.Collections.Generic;
using Models = NettrimCh.Api.DataAccess.Contracts.Models;

namespace NettrimCh.Api.Domain.Mapping.Extension.Tarea
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

        public static IEnumerable<Entities.TareaEntity> toEntity(this IEnumerable<Models.Tarea> model)
        {
            return model == null ? null : Mapper.Map<IEnumerable<Models.Tarea>, IEnumerable<Entities.TareaEntity>>(model);
        }
        public static Entities.TareaEntity toEntity(this Models.Tarea model)
        {
            return model == null ? null : Mapper.Map<Models.Tarea, Entities.TareaEntity>(model);
        }

        public static Models.Tarea toModel (this Entities.TareaEntity entity)
        {
            return entity == null ? null : Mapper.Map<Entities.TareaEntity, Models.Tarea>(entity);
        }



    }
}
