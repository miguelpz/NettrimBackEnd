using System;
using System.Collections.Generic;
using System.Text;

namespace NettrimCh.Api.Domain.ServicesContracts
{
    public interface ICustomFindable<M>
    {
        M GetSingleOrDefault(string field);
    }
}
