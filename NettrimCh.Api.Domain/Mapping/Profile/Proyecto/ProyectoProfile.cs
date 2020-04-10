using System;
using System.Collections.Generic;
using System.Text;
using Models = NettrimCh.Api.DataAccess.Contracts.Models;

namespace NettrimCh.Api.Domain.Mapping.Profile.Proyecto
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
