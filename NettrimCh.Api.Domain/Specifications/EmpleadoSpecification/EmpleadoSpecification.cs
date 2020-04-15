using NettrimCh.Api.Domain.Entities;
using NettrimCh.Api.Domain.Specifications.GlobalSpecifications.ClaveSpecification;
using NettrimCh.Api.Domain.Specifications.GlobalSpecifications.DNISpecification;
using NettrimCh.Api.Domain.Specifications.GlobalSpecifications.EmailSpecification;
using System;
using System.Collections.Generic;
using System.Text;

namespace NettrimCh.Api.Domain.Specifications.EmpleadoSpecification
{
    public class EmpleadoSpecification : IEmpleadoSpecification
    {
        private readonly IIsEmailSpecification _emailSpecification;
        private readonly IIsDNISpecification _dNISpecification;
        private readonly IClaveSpecification _claveSpecification;


        public EmpleadoSpecification(IIsEmailSpecification emailSpecification, IIsDNISpecification dNISpecification, IClaveSpecification claveSpecification)
        {
            _emailSpecification = emailSpecification;
            _dNISpecification = dNISpecification;
            _claveSpecification = claveSpecification;
        }
        public bool IsSatisfiedBy(EmpleadoEntity empleado)
        {
            return (_emailSpecification.isSatisfiedBy(empleado.Email) && _dNISpecification.isSatisfiedBy(empleado.Password)
                && _claveSpecification.IsSatisfiedBy(empleado.Password));

        }
    }
}
