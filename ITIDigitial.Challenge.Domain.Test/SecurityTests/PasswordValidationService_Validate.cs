using ITIDigitial.Challenge.Domain.Aggregates.SecurityAggregate.Services;
using Xunit;

namespace ITIDigitial.Challenge.Domain.Test.SecurityTests
{
    public class PasswordValidationService_Validate
    {
        private readonly IPasswordValidationService _passwordValidationService;

        public PasswordValidationService_Validate()
        {
            _passwordValidationService = new PasswordValidationService();
        }

        [Theory]
        [InlineData("")]
        [InlineData("aa")]
        [InlineData("ab")]
        [InlineData("AAAbbbCc")]
        [InlineData("AboTp9!fo")]
        [InlineData("9AbTp9!fo")]
        [InlineData("AbTp9 fok")]
        [InlineData("AbTp9_fok")]
        [InlineData("AbTp9Çfok")]
        public void Validate_ReturnFalse(string password)
        {
            var result = _passwordValidationService.Validate(password);

            Assert.False(result, $"{password} - A senha não atende a todos os requisitos");
        }

        [Theory]
        [InlineData("AbTp9!fok")]
        [InlineData("Aa1bTp9#fo2k")]
        [InlineData("abTp9%fok")]
        [InlineData("123aA%$456")]
        [InlineData("abTp9%fkoc")]
        public void Validate_ReturnTrue(string password)
        {
            var result = _passwordValidationService.Validate(password);

            Assert.True(result, $"{password} - A senha atende a todos os requisitos");
        }
    }
}
