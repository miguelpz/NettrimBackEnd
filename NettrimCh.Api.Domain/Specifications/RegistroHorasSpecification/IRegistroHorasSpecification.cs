using NettrimCh.Api.Domain.Entities;

namespace NettrimCh.Api.Domain.Specifications.RegistroHorasSpecification
{
    public interface IRegistroHorasSpecification
    {
        bool IsSatisfiedBy(RegistroHorasEntity registroHoras);
    }
}