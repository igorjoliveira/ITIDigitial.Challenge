using System.Text.RegularExpressions;

namespace ITIDigitial.Challenge.Domain.Aggregates.SecurityAggregate.Services.PasswordRules
{
    public class UppercasePasswordRule : BasePasswordRule
    {
        public override string RegexPattern => @"^(.*[A-Z]\S*){1,}$";

        public override bool IsValid(string password)
        {
            return base.IsValid(password) && Regex.IsMatch(password, RegexPattern);
        }
    }
}
