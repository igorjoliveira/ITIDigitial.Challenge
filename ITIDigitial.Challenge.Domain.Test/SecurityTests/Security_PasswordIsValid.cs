using ITIDigitial.Challenge.Domain.Aggregates.SecurityAggregate;
using ITIDigitial.Challenge.Domain.Aggregates.SecurityAggregate.Services.PasswordRules;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace ITIDigitial.Challenge.Domain.Test.SecurityTests
{
    public class Security_PasswordIsValid
    {
        private readonly Mock<IPasswordRule> _mockPasswordRule1;
        private readonly Mock<IPasswordRule> _mockPasswordRule2;

        private readonly IEnumerable<IPasswordRule> _mocksPasswordRules;

        public Security_PasswordIsValid()
        {
            _mockPasswordRule1 = new Mock<IPasswordRule>();
            _mockPasswordRule2 = new Mock<IPasswordRule>();

            _mocksPasswordRules = new List<IPasswordRule>()
            {
                _mockPasswordRule1.Object,
                _mockPasswordRule2.Object
            };
        }

        [Fact]
        public void PasswordIsValid_ReturnFalse()
        {
            var password = It.IsAny<string>();

            _mockPasswordRule1.Setup(x => x.IsValid(password)).Returns(false);
            _mockPasswordRule2.Setup(x => x.IsValid(password)).Returns(true);            

            var entity = new Security(password);
            var result = entity.PasswordIsValid(_mocksPasswordRules);

            Assert.False(result, $"{password} - A senha não atende a todos os requisitos");
        }

        [Fact]
        public void PasswordIsValid_ReturnTrue()
        {
            var password = It.IsAny<string>();

            _mockPasswordRule1.Setup(x => x.IsValid(password)).Returns(true);
            _mockPasswordRule2.Setup(x => x.IsValid(password)).Returns(true);

            var entity = new Security(password);
            var result = entity.PasswordIsValid(_mocksPasswordRules);

            Assert.True(result, $"{password} - A senha atende a todos os requisitos");
        }
    }
}
