namespace NettrimCh.Api.Domain.Specifications.GlobalSpecifications.TelefonoSpecification
{
    public interface IIsTelefonoSpecification
    {
        bool IsSatisfiedBy(string telefono);
    }
}