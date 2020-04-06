using AutoMapper;
using NettrimCh.Api.Domain.Mapping.Profile.Cliente;
using System;
using System.Collections.Generic;
using System.Text;
using Models = NettrimCh.Api.DataAccess.Contracts.Models;
using Entities = NettrimCh.Api.Domain.Entities;
using NettrimCh.Api.Domain.Mapping.Profile.TareaAdjuntos;

namespace NettrimCh.Api.Domain.Mapping.Extension.TareaAdjuntos
{
    public static class TareaAdjuntosMapper
    {
        internal static IMapper Mapper { get; }

        static TareaAdjuntosMapper()
        {
            Mapper = new MapperConfiguration
                    (cfg => { cfg.AddProfile<TareaAdjuntosProfile>(); })
                .CreateMapper();
        }

        public static IEnumerable<Entities.TareaAdjuntosEntity> toEntity(this IEnumerable<Models.TareaAdjuntos> model)
        {
            return model == null ? null : Mapper.Map<IEnumerable<Models.TareaAdjuntos>, IEnumerable<Entities.TareaAdjuntosEntity>>(model);
        }
        public static Entities.TareaAdjuntosEntity toEntity(this Models.TareaAdjuntos model)
        {
            return model == null ? null : Mapper.Map<Models.TareaAdjuntos, Entities.TareaAdjuntosEntity>(model);
        }

        public static Models.TareaAdjuntos toModel (this Entities.TareaAdjuntosEntity entity)
        {
            return entity == null ? null : Mapper.Map<Entities.TareaAdjuntosEntity, Models.TareaAdjuntos>(entity);
        }



    }
}
