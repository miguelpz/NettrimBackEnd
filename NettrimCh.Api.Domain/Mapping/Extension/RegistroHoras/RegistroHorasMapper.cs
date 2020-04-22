using AutoMapper;
using NettrimCh.Api.Domain.Mapping.Profile.Cliente;
using System;
using System.Collections.Generic;
using System.Text;
using Models = NettrimCh.Api.DataAccess.Contracts.Models;
using Entities = NettrimCh.Api.Domain.Entities;
using NettrimCh.Api.Domain.Mapping.Profile.RegistroHoras;

namespace NettrimCh.Api.Domain.Mapping.Extension.RegistroHoras
{
    public static class RegistroHorasMapper
    {
        internal static IMapper Mapper { get; }

        static RegistroHorasMapper()
        {
            Mapper = new MapperConfiguration
                    (cfg => { cfg.AddProfile<RegistroHorasProfile>(); })
                .CreateMapper();
        }

        public static IEnumerable<Entities.RegistroHorasEntity> toEntity(this IEnumerable<Models.RegistroHoras> model)
        {
            return model == null ? null : Mapper.Map<IEnumerable<Models.RegistroHoras>, IEnumerable<Entities.RegistroHorasEntity>>(model);
        }
        public static Entities.RegistroHorasEntity toEntity(this Models.RegistroHoras model)
        {
            return model == null ? null : Mapper.Map<Models.RegistroHoras, Entities.RegistroHorasEntity>(model);
        }

        public static Models.RegistroHoras toModel (this Entities.RegistroHorasEntity entity)
        {
            return entity == null ? null : Mapper.Map<Entities.RegistroHorasEntity, Models.RegistroHoras>(entity);
        }

        public static IEnumerable<Models.RegistroHoras> toModel(this IEnumerable<Entities.RegistroHorasEntity> entity)
        {
            var result = entity == null ? null : Mapper.Map<IEnumerable<Entities.RegistroHorasEntity>, IEnumerable<Models.RegistroHoras>>(entity);

            return entity == null ? null : Mapper.Map<IEnumerable<Entities.RegistroHorasEntity>, IEnumerable<Models.RegistroHoras>>(entity);
        }



    }
}
