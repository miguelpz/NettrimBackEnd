using System;
using System.Collections.Generic;
using System.Text;
using Models = NettrimCh.Api.DataAccess.Contracts.Models;
using Entities = NettrimCh.Api.Domain.Entities;
using System.Linq;

namespace NettrimCh.Api.Domain.Mapping.Profile.Tarea
{
    public class TareaProfile : AutoMapper.Profile
    {
        public TareaProfile()
        {
            CreateMap<Models.Tarea, Entities.TareaEntity>()
                .ReverseMap();          
        }
    }
}
