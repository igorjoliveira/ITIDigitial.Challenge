using ITIDigitial.Challenge.Domain.Aggregates.SecurityAggregate.Services.PasswordRules;
using Xunit;

namespace ITIDigitial.Challenge.Domain.Test.SecurityTests
{
    public class SpecialCharPasswordRule_IsValid
    {
        private readonly IPasswordRule _passwordRule;
        public SpecialCharPasswordRule_IsValid()
        {
            _passwordRule = new SpecialCharPasswordRule();
        }

        [Theory]
        [InlineData("abcã!a")]
        [InlineData("abcÇ@def")]
        [InlineData("Abtp9é#FOK")]
        public void IsValid_CharInvalid_ReturnFalse(string password)
        {
            var result = _passwordRule.IsValid(password);

            Assert.False(result, $"{password} - A senha deve conter um caractere inválido");
        }

        [Theory]
        [InlineData("abcaa")]
        [InlineData("aBcdef")]
        [InlineData("Abtp9FOK")]
        public void IsValid_ReturnFalse(string password)
        {
            var result = _passwordRule.IsValid(password);

            Assert.False(result, $"{password} - A senha deve conter ao menos 1 caractere especial");
        }

        [Theory]
        [InlineData("%abTa")]
        [InlineData("Abtp9&")]
        [InlineData("abtp9#foKk")]
        [InlineData("AabtpP9#foK12")]
        [InlineData("%AabtpP9#foK12#")]
        public void IsValid_ReturnTrue(string password)
        {
            var result = _passwordRule.IsValid(password);

            Assert.True(result, $"{password} - A senha contém ao menos 1 caractere especial");
        }
    }
}
