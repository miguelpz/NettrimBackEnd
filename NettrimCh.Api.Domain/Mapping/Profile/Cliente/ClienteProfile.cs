using System;
using System.Collections.Generic;
using System.Text;
using Models = NettrimCh.Api.DataAccess.Contracts.Models;
using Entities = NettrimCh.Api.Domain.Entities;
using System.Linq;

namespace NettrimCh.Api.Domain.Mapping.Profile.Cliente
{
    public class ClienteProfile : AutoMapper.Profile
    {
        public ClienteProfile()
        {
            CreateMap<Models.ClienteModel, Entities.ClienteEntity>()
                .ReverseMap();
            //CreateMap<IEnumerable<Models.ClienteModel>, IEnumerable<Entities.ClienteEntity>>()
            //    .ForMember(destino => destino.Select(a => a.Cliente), origen => origen.MapFrom(c => c.Select(s => s.Cliente)));


        }
    }
}
