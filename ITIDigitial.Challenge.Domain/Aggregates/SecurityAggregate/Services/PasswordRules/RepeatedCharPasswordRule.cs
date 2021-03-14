using System.Linq;

namespace ITIDigitial.Challenge.Domain.Aggregates.SecurityAggregate.Services.PasswordRules
{
    public class RepeatedCharPasswordRule : BasePasswordRule
    {
        public override bool IsValid(string password)
        {
            return base.IsValid(password) 
                && !password.Select(x => x)
                            .GroupBy(x => x)
                            .Any(x => x.Count() > 1);
        }
    }
}
