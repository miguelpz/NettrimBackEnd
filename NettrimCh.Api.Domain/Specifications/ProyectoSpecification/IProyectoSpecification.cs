using NettrimCh.Api.Domain.Entities;

namespace NettrimCh.Api.Domain.Specifications.ProyectoSpecification
{
    public interface IProyectoSpecification
    {
        bool IsSatisfiedBy(ProyectoEntity proyecto);
    }
}