using ITIDigitial.Challenge.Application.ApplicationServices;
using ITIDigitial.Challenge.Application.Interfaces.ApplicationServices;
using ITIDigitial.Challenge.Domain.Aggregates.SecurityAggregate.Services;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace ITIDigitial.Challenge.Application.Test.SecurityApplicationServiceTests
{
    public class SecurityApplicationService_ValidatePassword
    {
        private readonly Mock<IPasswordValidationService> _mockPasswordValidationService;
        private readonly ISecurityApplicationService _securityApplicationService;

        public SecurityApplicationService_ValidatePassword()
        {
            _mockPasswordValidationService = new Mock<IPasswordValidationService>();
            _securityApplicationService = new SecurityApplicationService(_mockPasswordValidationService.Object);
        }

        [Fact]
        public async Task ValidatePasswordAsync_IsNullOrEmpty_ReturnFalse()
        {
            var password = string.Empty;

            _mockPasswordValidationService.Setup(x => x.Validate(password)).Returns(false);

            var result = await _securityApplicationService.ValidatePasswordAsync(password);

            Assert.False(result, $"{password} - A senha não atende a todos os requisitos");
        }

        [Fact]
        public async Task ValidatePasswordAsync_ReturnFalse()
        {
            var password = "AbTp9 fok";

            _mockPasswordValidationService.Setup(x => x.Validate(password)).Returns(false);

            var result = await _securityApplicationService.ValidatePasswordAsync(password);

            Assert.False(result, $"{password} - A senha não atende a todos os requisitos");
        }

        [Fact]
        public async Task ValidatePasswordAsync_ReturnTrue()
        {
            var password = "AbTp9!fok";

            _mockPasswordValidationService.Setup(x => x.Validate(password)).Returns(true);

            var result = await _securityApplicationService.ValidatePasswordAsync(password);

            Assert.True(result, $"{password} - A senha atende a todos os requisitos");
        }
    }
}
