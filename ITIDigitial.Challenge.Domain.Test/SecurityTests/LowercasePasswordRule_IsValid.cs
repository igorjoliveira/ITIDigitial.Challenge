using ITIDigitial.Challenge.Domain.Aggregates.SecurityAggregate.Services.PasswordRules;
using Xunit;

namespace ITIDigitial.Challenge.Domain.Test.SecurityTests
{
    public class LowercasePasswordRule_IsValid
    {
        private readonly IPasswordRule _passwordRule;
        public LowercasePasswordRule_IsValid()
        {
            _passwordRule = new LowercasePasswordRule();
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
        [InlineData("ABT")]
        [InlineData("ABTP9")]
        [InlineData("ABTP9#FOK")]
        public void IsValid_ReturnFalse(string password)
        {
            var result = _passwordRule.IsValid(password);

            Assert.False(result, $"{password} - A senha deve ter ao menos 1 letra minúscula");
        }

        [Theory]
        [InlineData("AbT")]
        [InlineData("aBTP9")]
        [InlineData("ABTP9#FoK")]
        [InlineData("ABTP9#FOK1a2")]
        public void IsValid_ReturnTrue(string password)
        {
            var result = _passwordRule.IsValid(password);

            Assert.True(result, $"{password} - A senha contém ao menos 1 letra minúscula");
        }
    }
}
