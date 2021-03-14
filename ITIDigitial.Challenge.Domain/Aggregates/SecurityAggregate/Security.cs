using ITIDigitial.Challenge.Domain.Aggregates.SecurityAggregate.Services.PasswordRules;
using System.Collections.Generic;
using System.Linq;

namespace ITIDigitial.Challenge.Domain.Aggregates.SecurityAggregate
{
    public class Security
    {
        public string Password { get; private set; }

        public Security(string password)
        {
            Password = password;
        }

        public bool PasswordIsValid(IEnumerable<IPasswordRule> passwordRules)
            => passwordRules.All(x => x.IsValid(Password));
    }
}
