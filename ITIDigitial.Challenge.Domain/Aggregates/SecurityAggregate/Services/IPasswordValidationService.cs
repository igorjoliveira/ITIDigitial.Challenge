namespace ITIDigitial.Challenge.Domain.Aggregates.SecurityAggregate.Services
{
    public interface IPasswordValidationService
    {
        bool Validate(string password);
    }
}
