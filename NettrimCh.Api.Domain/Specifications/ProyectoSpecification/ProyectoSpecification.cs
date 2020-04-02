using NettrimCh.Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NettrimCh.Api.Domain.Specifications.ProyectoSpecification
{
    public class ProyectoSpecification : IProyectoSpecification
    {
        public bool IsSatisfiedBy(ProyectoEntity proyecto)
        {
            return true;

        }
    }
}
