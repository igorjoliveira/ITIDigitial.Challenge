namespace ITIDigitial.Challenge.Domain.Aggregates.SecurityAggregate.Services.PasswordRules
{
    public interface IPasswordRule
    {
        string RegexPattern { get; }
        bool IsValid(string password);
    }
}
