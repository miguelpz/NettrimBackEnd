namespace NettrimCh.Api.Domain.Specifications.GlobalSpecifications
{
    public class NotNullSpecification : INotNullSpecification
    {
        public bool IsSatisfiedBy(string s)
        {
            return !string.IsNullOrEmpty(s);
        }
    }
}
