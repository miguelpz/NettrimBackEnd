using NettrimCh.Api.Domain.Entities;

namespace NettrimCh.Api.Domain.Specifications.TareaSpecification
{
    public interface ITareaSpecification
    {
        bool IsSatisfiedBy(TareaEntity tarea);
    }
}