using NettrimCh.Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NettrimCh.Api.Domain.Specifications.TareaSpecification
{
    public class TareaSpecification : ITareaSpecification
    {
        public bool IsSatisfiedBy(TareaEntity tarea)
        {
            return true;

        }
    }
}
