using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace NettrimCh.Api.Domain.Specifications.GlobalSpecifications.ClaveSpecification
{
    public class ClaveSpecification : IClaveSpecification
    {
        public bool IsSatisfiedBy(string clave)
        {
            if (Regex.IsMatch(clave, @"/^(?=.*\d)(?=.*[A-Z])(?=.*[a-z])\S{8,16}$"))
            {
                return true;
            }
            return false;
        }
    }
}
