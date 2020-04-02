using System.Text.RegularExpressions;

namespace NettrimCh.Api.Domain.Specifications.GlobalSpecifications.DNISpecification
{
    public class IsDNISpecification : IIsDNISpecification
    {
        public bool isSatisfiedBy(string dni)
        {

            return Regex.IsMatch(dni, @"/^(x?\d{8}|[xyz]\d{7})[trwagmyfpdxbnjzsqvhlcke]$/");
           
        }
    }
}
