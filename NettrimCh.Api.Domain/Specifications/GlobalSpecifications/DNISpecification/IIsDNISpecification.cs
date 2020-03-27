namespace NettrimCh.Api.Domain.Specifications.GlobalSpecifications.DNISpecification
{
    public interface IIsDNISpecification
    {
        bool isSatisfiedBy(string dni);
    }
}
