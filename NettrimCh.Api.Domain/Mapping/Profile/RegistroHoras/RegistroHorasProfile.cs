using System;
using System.Collections.Generic;
using System.Text;
using Models = NettrimCh.Api.DataAccess.Contracts.Models;
using Entities = NettrimCh.Api.Domain.Entities;
using System.Linq;

namespace NettrimCh.Api.Domain.Mapping.Profile.RegistroHoras
{
    public class RegistroHorasProfile : AutoMapper.Profile
    {
        public RegistroHorasProfile()
        {
            CreateMap<Models.RegistroHoras, Entities.RegistroHorasEntity>()
                .ReverseMap();          
        }
    }
}
