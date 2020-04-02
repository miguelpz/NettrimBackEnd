using NettrimCh.Api.Domain.Entities;

namespace NettrimCh.Api.Domain.Specifications.EmpleadoSpecification
{
    public interface IEmpleadoSpecification
    {
        bool IsSatisfiedBy(EmpleadoEntity empleado);
    }
}