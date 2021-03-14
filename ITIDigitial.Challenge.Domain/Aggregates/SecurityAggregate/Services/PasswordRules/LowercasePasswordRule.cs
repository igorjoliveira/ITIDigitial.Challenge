using System.Text.RegularExpressions;

namespace ITIDigitial.Challenge.Domain.Aggregates.SecurityAggregate.Services.PasswordRules
{
    public class LowercasePasswordRule : BasePasswordRule
    {
        public override string RegexPattern => @"^(.*[a-z]\S*){1,}$";

        public override bool IsValid(string password)
        {
            return base.IsValid(password) && Regex.IsMatch(password, RegexPattern);
        }
    }
}
