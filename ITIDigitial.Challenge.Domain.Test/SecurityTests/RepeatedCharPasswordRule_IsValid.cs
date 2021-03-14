using ITIDigitial.Challenge.Domain.Aggregates.SecurityAggregate.Services.PasswordRules;
using Xunit;

namespace ITIDigitial.Challenge.Domain.Test.SecurityTests
{
    public class RepeatedCharPasswordRule_IsValid
    {
        private readonly IPasswordRule _passwordRule;
        public RepeatedCharPasswordRule_IsValid()
        {
            _passwordRule = new RepeatedCharPasswordRule();
        }

        [Theory]
        [InlineData("abc !a")]
        [InlineData("abc/@def")]
        [InlineData("Abtp9{#FOK")]
        public void IsValid_CharInvalid_ReturnFalse(string password)
        {
            var result = _passwordRule.IsValid(password);

            Assert.False(result, $"{password} - A senha deve conter um caractere inválido");
        }

        [Theory]
        [InlineData("abc!a")]
        [InlineData("aBBc@def")]
        [InlineData("Abtp9#FFOK")]
        [InlineData("Abtp99#FOK")]
        [InlineData("Abtp99##FOK")]
        public void IsValid_ReturnFalse(string password)
        {
            var result = _passwordRule.IsValid(password);

            Assert.False(result, $"{password} - A senha deve possuir caracteres repetidos (na sequência ignorando) dentro do conjunto");
        }

        [Theory]
        [InlineData("abT")]
        [InlineData("Abtp9")]
        [InlineData("abtp9#foKk")]
        [InlineData("AabtpP9#foK12")]
        public void IsValid_ReturnTrue(string password)
        {
            var result = _passwordRule.IsValid(password);

            Assert.True(result, $"{password} - A senha não possui caracteres repetidos (na sequência) dentro do conjunto");
        }
    }
}
