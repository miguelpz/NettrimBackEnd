using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NettrimCh.Api.Domain.Specifications.GlobalSpecifications
{
    public interface INotNullSpecification
    {
        bool IsSatisfiedBy(string s);
    }
}
