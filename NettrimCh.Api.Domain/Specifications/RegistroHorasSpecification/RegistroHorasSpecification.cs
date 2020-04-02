using NettrimCh.Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NettrimCh.Api.Domain.Specifications.RegistroHorasSpecification
{
    public class RegistroHorasSpecification : IRegistroHorasSpecification
    {
        public bool IsSatisfiedBy(RegistroHorasEntity registroHoras)
        {
            return (registroHoras.Horas > 0);

        }
    }
}
