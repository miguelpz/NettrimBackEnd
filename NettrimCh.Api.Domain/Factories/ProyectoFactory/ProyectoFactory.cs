using NettrimCh.Api.Domain.Entities;
using NettrimCh.Api.Domain.Exceptions.FactoryExceptions;
using NettrimCh.Api.Domain.Specifications.ProyectoSpecification;
using System;
using System.Collections.Generic;
using System.Text;

namespace NettrimCh.Api.Domain.Factories.ProyectoFactory
{
    public class ProyectoFactory : IProyectoFactory
    {
        private readonly IProyectoSpecification _specification;

        public ProyectoFactory(IProyectoSpecification specification)
        {
            _specification = specification;
        }

        public ProyectoEntity Instanciar(ProyectoEntity p)
        {
            if (p != null)
            {

                if (_specification.IsSatisfiedBy(p))
                {
                    return p;
                }
                throw new ImposibleCrearProyectoException("No se ha podido crear el cliente: " + p.Nombre + ", porque hay datos incorrectos.");
            }
            throw new ImposibleCrearProyectoException("No se ha podido crear el cliente porque es nulo.");
        }

    }
}
