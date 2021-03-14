using System.Text.RegularExpressions;

namespace ITIDigitial.Challenge.Domain.Aggregates.SecurityAggregate.Services.PasswordRules
{
    public class LengthPasswordRule : BasePasswordRule
    {
        public override string RegexPattern => @"^([0-9a-zA-Z!@#$%^&*()-+]\S*){9,}$";

        public override bool IsValid(string password)
        {
            return base.IsValid(password) && Regex.IsMatch(password, RegexPattern);
        }
    }
}
