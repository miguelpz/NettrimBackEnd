using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace NettrimCh.Api.Domain.Specifications.GlobalSpecifications.TelefonoSpecification
{
    public class IsTelefonoSpecification : IIsTelefonoSpecification
    {
        public bool IsSatisfiedBy(string telefono)
        {

            if (Regex.IsMatch(telefono, @"^([+]?[0]{0,2}\d{1,2}[-\s]?|)[9|6|7]\d{8}$"))
            {
                return true;
            }
            return false;
        }
    }
}
