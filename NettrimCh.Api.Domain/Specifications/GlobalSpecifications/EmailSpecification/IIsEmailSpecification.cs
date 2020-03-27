namespace NettrimCh.Api.Domain.Specifications.GlobalSpecifications.EmailSpecification
{
    public interface IIsEmailSpecification 
    {
        bool isSatisfiedBy(string email);
    }
}
