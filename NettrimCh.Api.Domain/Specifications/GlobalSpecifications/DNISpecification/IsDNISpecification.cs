using System.Text.RegularExpressions;

namespace NettrimCh.Api.Domain.Specifications.GlobalSpecifications.DNISpecification
{
    public class IsDNISpecification : IIsDNISpecification
    {
        public bool isSatisfiedBy(string dni)
        {
            var nifRexp = "/ ^[0 - 9]{ 8}[TRWAGMYFPDXBNJZSQVHLCKET]$/i";
            var nieRexp = "/ ^[XYZ][0 - 9]{7}[TRWAGMYFPDXBNJZSQVHLCKET]$/i";

            Regex validateNif = new Regex(nifRexp);
            Regex validateNie = new Regex(nieRexp);

            if (validateNif.IsMatch(dni))
            {
                return true;
            }
            else if (validateNie.IsMatch(dni))
            {
                return true;
            }
            return false;
        }
    }
}
