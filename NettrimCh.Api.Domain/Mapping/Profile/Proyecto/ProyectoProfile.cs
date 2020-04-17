using System;
using System.Collections.Generic;
using System.Text;
using Models = NettrimCh.Api.DataAccess.Contracts.Models;
using Entities = NettrimCh.Api.Domain.Entities;
using System.Linq;

namespace NettrimCh.Api.Domain.Mapping.Profile.Cliente
{
    public class ProyectoProfile : AutoMapper.Profile
    {
        public ProyectoProfile()
        {
            CreateMap<Models.Proyecto, Entities.ProyectoEntity>()
                .ReverseMap();          
        }
    }
}
