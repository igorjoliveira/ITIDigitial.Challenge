using ITIDigitial.Challenge.Domain.Aggregates.SecurityAggregate.Services.PasswordRules;
using Xunit;

namespace ITIDigitial.Challenge.Domain.Test.SecurityTests
{
    public class UppercasePasswordRule_IsValid
    {
        private readonly IPasswordRule _passwordRule;
        public UppercasePasswordRule_IsValid()
        {
            _passwordRule = new UppercasePasswordRule();
        }

        [Theory]
        [InlineData("AbTP9 !FOK")]
        [InlineData("ABTP9/@Fok")]
        [InlineData("Abtp9{#FOK")]
        public void IsValid_CharInvalid_ReturnFalse(string password)
        {
            var result = _passwordRule.IsValid(password);

            Assert.False(result, $"{password} - A senha deve conter um caractere inválido");
        }

        [Theory]
        [InlineData("abt")]
        [InlineData("abtp9")]
        [InlineData("abtp9#fok")]
        public void IsValid_ReturnFalse(string password)
        {
            var result = _passwordRule.IsValid(password);

            Assert.False(result, $"{password} - A senha deve conter ao menos 1 letra maiúscula");
        }

        [Theory]
        [InlineData("abT")]
        [InlineData("Abtp9")]
        [InlineData("abtp9#foK")]
        [InlineData("Abtp9#foK12")]
        public void IsValid_ReturnTrue(string password)
        {
            var result = _passwordRule.IsValid(password);

            Assert.True(result, $"{password} - A senha contém ao menos 1 letra maiúscula");
        }
    }
}
