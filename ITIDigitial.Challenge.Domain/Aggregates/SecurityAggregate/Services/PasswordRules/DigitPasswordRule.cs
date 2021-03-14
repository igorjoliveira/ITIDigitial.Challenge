using System.Text.RegularExpressions;

namespace ITIDigitial.Challenge.Domain.Aggregates.SecurityAggregate.Services.PasswordRules
{
    public class DigitPasswordRule : BasePasswordRule
    {
        public override string RegexPattern => @"^.*[0-9].*$";

        public override bool IsValid(string password)
        {
            return base.IsValid(password) && Regex.IsMatch(password, RegexPattern);  
        }
    }
}
