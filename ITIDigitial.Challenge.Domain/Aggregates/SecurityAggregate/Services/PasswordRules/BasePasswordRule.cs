using System.Text.RegularExpressions;

namespace ITIDigitial.Challenge.Domain.Aggregates.SecurityAggregate.Services.PasswordRules
{
    public abstract class BasePasswordRule : IPasswordRule
    {
        private string _baseRegexPattern => @"^([0-9a-zA-Z!@#$%^&*()-+])*$";

        public virtual string RegexPattern { get; }

        public virtual bool IsValid(string password)
        {
            return Regex.IsMatch(password, _baseRegexPattern);
        }
    }
}
