using ITIDigitial.Challenge.Domain.Aggregates.SecurityAggregate.Services.PasswordRules;
using Xunit;

namespace ITIDigitial.Challenge.Domain.Test.SecurityTests
{
    public class DigitPasswordRule_IsValid
    {
        private readonly IPasswordRule _passwordRule;
        public DigitPasswordRule_IsValid()
        {
            _passwordRule = new DigitPasswordRule();
        }

        [Theory]
        [InlineData("a_1")]
        [InlineData("bé2")]
        [InlineData("c/1")]
        public void IsValid_CharInvalid_ReturnFalse(string password)
        {
            var result = _passwordRule.IsValid(password);

            Assert.False(result, $"{password} - A senha deve ter um caractere inválido");
        }

        [Theory]
        [InlineData("a!")]
        [InlineData("b@")]
        [InlineData("ba")]
        public void IsValid_ReturnFalse(string password)
        {
            var result = _passwordRule.IsValid(password);

            Assert.False(result, $"{password} - A senha de conter ao menos 1 dígito");
        }

        [Theory]
        [InlineData("a1")]
        [InlineData("b2")]
        [InlineData("b3")]
        public void IsValid_ReturnTrue(string password)
        {
            var result = _passwordRule.IsValid(password);

            Assert.True(result, $"{password} - A senha contém ao menos 1 dígito");
        }
    }
}
