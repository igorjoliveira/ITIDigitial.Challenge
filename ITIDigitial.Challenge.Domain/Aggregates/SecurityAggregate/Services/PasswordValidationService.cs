using ITIDigitial.Challenge.Domain.Aggregates.SecurityAggregate.Services.PasswordRules;
using System.Collections.Generic;

namespace ITIDigitial.Challenge.Domain.Aggregates.SecurityAggregate.Services
{
    public class PasswordValidationService : IPasswordValidationService
    {
        private readonly IEnumerable<IPasswordRule> _passwordRules;

        public PasswordValidationService()
        {
            _passwordRules = new List<IPasswordRule>() 
            {
                new DigitPasswordRule(),
                new LengthPasswordRule(),
                new LowercasePasswordRule(),
                new RepeatedCharPasswordRule(),
                new SpecialCharPasswordRule(),
                new UppercasePasswordRule()
            };
        }

        public bool Validate(string password)
        {
            var entity = new Security(password);
            return entity.PasswordIsValid(_passwordRules);
        }
    }
}
