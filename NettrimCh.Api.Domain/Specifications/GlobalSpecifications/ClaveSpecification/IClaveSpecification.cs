namespace NettrimCh.Api.Domain.Specifications.GlobalSpecifications.ClaveSpecification
{
    public interface IClaveSpecification
    {
        bool IsSatisfiedBy(string clave);
    }
}