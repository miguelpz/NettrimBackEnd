using System;
using System.Collections.Generic;
using System.Text;

namespace NettrimCh.Api.Domain.Mapping.Profile
{
    public class GenericProfile<M,E>: AutoMapper.Profile where M:class where E:class
    {

        public GenericProfile()
        {
            CreateMap<M,E>()
                .ReverseMap();
        }
    }
}
