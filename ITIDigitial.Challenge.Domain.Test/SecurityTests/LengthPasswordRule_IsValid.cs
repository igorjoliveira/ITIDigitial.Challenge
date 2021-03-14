using ITIDigitial.Challenge.Domain.Aggregates.SecurityAggregate.Services.PasswordRules;
using Xunit;

namespace ITIDigitial.Challenge.Domain.Test.SecurityTests
{
    public class LengthPasswordRule_IsValid
    {
        private readonly IPasswordRule _passwordRule;
        public LengthPasswordRule_IsValid()
        {
            _passwordRule = new LengthPasswordRule();
        }

        [Theory]
        [InlineData("AbTp9 !fok")]
        [InlineData("AbTp9/@fok")]
        [InlineData("AbTp9{#fok")]
        public void IsValid_CharInvalid_ReturnFalse(string password)
        {
            var result = _passwordRule.IsValid(password);

            Assert.False(result, $"{password} - A senha deve conter um caractere inválido");
        }

        [Theory]        
        [InlineData("AbT")]
        [InlineData("AbTp9")]
        [InlineData("AbTp9fok")]
        public void IsValid_ReturnFalse(string password)
        {
            var result = _passwordRule.IsValid(password);

            Assert.False(result, $"{password} - A senha deve conter nove ou mais caracteres");
        }

        [Theory]
        [InlineData("AbTp9!fok")]
        [InlineData("AbTp9@fok2H")]
        [InlineData("AbTp9#fok4Tr")]
        public void IsValid_ReturnTrue(string password)
        {
            var result = _passwordRule.IsValid(password);

            Assert.True(result, $"{password} - A senha contém nove ou mais caracteres");
        }
    }
}
