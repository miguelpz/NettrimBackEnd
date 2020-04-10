using NettrimCh.Api.Domain.Entities;

namespace NettrimCh.Api.Domain.Factories.ProyectoFactory
{
    public interface IProyectoFactory
    {
        ProyectoEntity Instanciar(ProyectoEntity p);
    }
}