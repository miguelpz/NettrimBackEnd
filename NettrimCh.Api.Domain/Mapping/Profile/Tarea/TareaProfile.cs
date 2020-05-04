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

            CreateMap<Entities.TareaEntity, Models.Tarea>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.FechaInicio, opt => opt.MapFrom(src => src.FechaInicio))
               .ForMember(dest => dest.TipoTareaId, opt => opt.MapFrom(src => src.TipoTareaId))
               .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.Descripcion))
               .ForMember(dest => dest.EmpleadoId, opt => opt.MapFrom(src => src.EmpleadoId))
               .ForMember(dest => dest.ProyectoId, opt => opt.MapFrom(src => src.ProyectoId))
               .ForMember(dest => dest.Finalizada, opt => opt.MapFrom(src => src.Finalizada))
               .ReverseMap();
        }
    }
}
