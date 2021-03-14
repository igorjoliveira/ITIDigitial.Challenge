using System.Text.RegularExpressions;

namespace ITIDigitial.Challenge.Domain.Aggregates.SecurityAggregate.Services.PasswordRules
{
    public class SpecialCharPasswordRule : BasePasswordRule
    {
        public override string RegexPattern => @"^.*([!@#$%^&*()-+]\S*){1,}$";

        public override bool IsValid(string password)
        {
            return base.IsValid(password) && Regex.IsMatch(password, RegexPattern);
        }
    }
}
