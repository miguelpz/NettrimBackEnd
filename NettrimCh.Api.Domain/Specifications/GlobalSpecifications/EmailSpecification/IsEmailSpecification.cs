using System.Text.RegularExpressions;

namespace NettrimCh.Api.Domain.Specifications.GlobalSpecifications.EmailSpecification
{
    public class IsEmailSpecification : IIsEmailSpecification
    {
        public bool isSatisfiedBy(string email)
        {
            if (Regex.IsMatch(email, @"/^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$/"))
            {
                return true;
            }
            return false;
        }
    }
}
