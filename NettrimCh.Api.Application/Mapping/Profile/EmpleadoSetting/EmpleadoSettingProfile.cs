using System;
using System.Collections.Generic;
using System.Text;
using Dtos = NettrimCh.Api.Application.Contracts.DTO;
using Entities = NettrimCh.Api.Domain.Entities;
using System.Linq;
using NettrimCh.Api.Application.Helpers;

namespace  NettrimCh.Api.Application.Mapping.Profile.EmpleadoSetting
{
    public class EmpleadoSettingProfile : AutoMapper.Profile
    {
        public EmpleadoSettingProfile()
        {
            CreateMap<Dtos.EmpleadoSettingsDto, Entities.EmpleadoSettingEntity>()
                .ForMember(dest => dest.HoraEntradaDefault, opt => opt.MapFrom(src => src.HoraEntradaDefault.GetHourMinutesTimeSpan()))
                .ForMember(dest => dest.HoraSalidaDefault, opt => opt.MapFrom(src => src.HoraSalidaDefault.GetHourMinutesTimeSpan()))
                .ForMember(dest => dest.TiempoDescansoDefault, opt => opt.MapFrom(src => src.TiempoDescansoDefault.GetHourMinutesTimeSpan()))
                .ReverseMap();
        }
    }
}
