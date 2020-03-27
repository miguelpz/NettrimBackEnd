namespace NettrimCh.Api.Domain.Specifications.GlobalSpecifications.EmailSpecification
{
    public class IsEmailSpecification : IIsEmailSpecification
    {
        public bool isSatisfiedBy(string email)
        {
            if (email.Contains("@"))
            {
                return true;
            }
            return false;
        }
    }
}
